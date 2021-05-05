using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Car
    {
        private int id = 0;
        private string mark = "";
        private string model = "";
        private int year = 0;
        private string color = "";
        private int cost = 0;
        public int num = 0;
        private readonly uint CarID;
        private static int size = 0;
        public static void sizeinfo()

        {
            Console.WriteLine("Size:" + size);
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }

        }
        public string MARK
        {
            get { return this.mark; }
            set { this.mark = value; }

        }
        public string MODEL
        {
            get { return this.model; }
            set { this.model = value; }

        }
        public int YEAR
        {
            get { return this.year; }
            set { this.year = value; }

        }
        public string COLOR
        {
            get { return this.color; }
            set { this.color = value; }

        }
        public int COST
        {
            get { return this.cost; }
            set { this.cost = value; }

        }




        public Car()
        {
            this.id = 0;
            this.mark = "no";
            this.model = "no";
            this.year = 0000;
            this.color = "no";
            this.cost = 0;
            this.num = 0;
            this.CarID = makeHash(id, mark, year, num);
            size++;
        }

        public Car(int iden, string m, string mod, int y, string col, int c, int n)
        {
            this.id = iden;
            this.mark = m;
            this.model = mod;
            this.year = y;
            this.color = col;
            this.cost = c;
            this.num = n;
            this.CarID = makeHash(id, mark, year, num);
            size++;
        }

        static Car()
        {
            Console.WriteLine("Добавлен первый автомобиль: ");
        }
        public Car(int iden, string m, int y)
        {
            this.id = iden;
            this.mark = m;
            this.year = y;
            this.CarID = makeHash(id, mark, year, num);
            size++;
        }

        public uint makeHash(int id, string mark, int year, int num)
        {
            int intRes = mark.Length + num * 9 - id;
            uint res = (uint)intRes;
            return res;
        }

        public static void show(string NewFirstName, string NewLastName)
        {
            Console.WriteLine($"Марка(ервый параметр) = {NewFirstName}");
            Console.WriteLine($"Модель(второй параметр) = {NewLastName}");
        }

    }
    


}
