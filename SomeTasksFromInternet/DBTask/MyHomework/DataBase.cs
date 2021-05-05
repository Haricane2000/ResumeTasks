using Microsoft.Data.SqlClient;

namespace _8th_homework
{
    public static class DataBase
    {
        public static SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ".\\SQLEXPRESS",
                InitialCatalog = "HomeworkDB",
                IntegratedSecurity = true,
                ConnectTimeout = 2
            };

            return new SqlConnection(builder.ToString());
        }
    }
}
