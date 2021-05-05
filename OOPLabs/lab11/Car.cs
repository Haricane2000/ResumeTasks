using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Car
    {
        public int[] Marks { get; set; }
        public int id { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int cost { get; set; }
        public int num { get; set; }
        private readonly uint CarID;
        public static int size = 0;
        public static void sizeinfo()

        {
            Console.WriteLine("Size:" + size);
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
            Console.WriteLine("Создан первый билет");
        }
        public Car(int iden, string m, int y)
        {
            this.id = iden;
            this.mark = m;
            this.year = y;
            this.CarID = makeHash(id, mark, year, num);
            size++;
        }

        public Car(string _Mark, string _Model) : this()
        {
            mark = _Mark;
            model = _Model;
            id = mark.GetHashCode() + model.GetHashCode();
        }
        public Car(string _Mark, string _Model, int[] _Marks) : this()
        {
            mark = _Mark;
            model = _Model;
            Marks = _Marks;
            id = mark.GetHashCode() + model.GetHashCode();
        }

        public double getSre()
        {
            double sum = 0;
            foreach (int x in Marks)
            {
                sum += x;
            }
            return (sum / Marks.Length);
        }

        public int getMin()
        {
            int min = Marks[0];
            foreach (int x in Marks)
            {
                if (x <= min)
                {
                    min = x;
                }
            }
            return min;
        }

        public int getMax()
        {
            int max = Marks[0];
            foreach (int x in Marks)
            {
                if (x >= max)
                {
                    max = x;
                }
            }
            return max;
        }

        public int getSum()
        {
            int sum = 0;
            foreach (int x in Marks)
            {
                sum += x;
            }
            return sum;
        }

        public override string ToString()
        {
            return (this.mark + " " + this.model);
        }


        public uint makeHash(int id, string mark, int year, int num)
        {
            int intRes = mark.Length + num * 9 - id;
            uint res = (uint)intRes;
            return res;
        }

    }


}

