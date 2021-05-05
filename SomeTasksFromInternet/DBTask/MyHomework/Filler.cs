using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace _8th_homework
{
    public class Filler
    {
        private string checkLine = string.Empty;
        private Guid guid = new Guid();
        private readonly Stream _stream;
        public Filler(Stream stream)
        {
            _stream = stream ?? throw new ArgumentNullException("NullArgument");
        }
        public void Fill()
        {
            SqlConnection _connection = DataBase.GetConnection();
            Clean(_connection);

            StreamReader sr = new StreamReader(_stream);
            List<string> str = new List<string>();

            while (!sr.EndOfStream)
            {
                try
                {
                    str.Add(sr.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var line in str)
            {

                FillDB(line);
            }
        }

        private void FillDB(string str)
        {

            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException("NullArgument");
            
            string[] line = str.Split(',',' ');

            if (line.Length == 4)
            {
                if ($"{line[0]}{line[1]}@issoft.by" != checkLine)
                {
                    guid = Guid.NewGuid();
                    checkLine = FillEmp(line, guid);
                }

                FillHol(line, guid);
            }
        }

        private string FillEmp(string[] line, Guid guid)
        {
            if (line == null)
                throw new ArgumentNullException("NullArgument");

            SqlConnection _connection = DataBase.GetConnection();
            string sqlEmp = "Insert into Employee values (@IdEmp, @Email, @FirstName, @SecondName)";
            
                var cmd = new SqlCommand(sqlEmp, _connection);


                cmd.Parameters.Add("@IdEmp", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@IdEmp"].Value = guid;

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 128);
                cmd.Parameters["@Email"].Value = $"{line[0]}{line[1]}@issoft.by";


                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 128);
                cmd.Parameters["@FirstName"].Value = line[0];

                cmd.Parameters.Add("@SecondName", SqlDbType.NVarChar, 128);
                cmd.Parameters["@SecondName"].Value = line[1];



                ExecuteNonQuery(cmd, _connection);
                return $"{line[0]}{line[1]}@issoft.by";
        }

        private void FillHol(string[] line, Guid guid)
        {
            if (line == null)
                throw new ArgumentNullException("NullArgument");

            SqlConnection _connection = DataBase.GetConnection();

            string sqlHol = "Insert into Holiday values (@IdHol, @StartHolidayDate, @EndHolidayDate, @EmployeeId)";

            var cmd = new SqlCommand(sqlHol, _connection);

            cmd.Parameters.Add("@IdHol", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@IdHol"].Value = Guid.NewGuid();

            cmd.Parameters.Add("@StartHolidayDate", SqlDbType.Date);
            cmd.Parameters["@StartHolidayDate"].Value = ParseDate(line[2]);

            cmd.Parameters.Add("@EndHolidayDate", SqlDbType.Date);
            cmd.Parameters["@EndHolidayDate"].Value = ParseDate(line[3]);

            cmd.Parameters.Add("@EmployeeId", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@EmployeeId"].Value = guid;

            ExecuteNonQuery(cmd, _connection);
        }

        private void ExecuteNonQuery(SqlCommand cmd, SqlConnection connection)
        {
            if(cmd == null || connection == null)
                throw new ArgumentNullException();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void Clean(SqlConnection _connection)
        {
            var cmd = new SqlCommand("Delete from Holiday; Delete from Employee", _connection);
            ExecuteNonQuery(cmd, _connection);
        }
        private static DateTime ParseDate(string s)
        {
            var parts = s.Split('/');
            return new DateTime(int.Parse(parts[2]), int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}
