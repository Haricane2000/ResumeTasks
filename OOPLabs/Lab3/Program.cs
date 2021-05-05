using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3lab
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
            this.color="no";
            this.cost = 0;
            this.num = 0;
            this.CarID = makeHash(id, mark, year, num);
            size++;
        }

        public Car(int iden, string m, string mod, int y, string col, int c,int n)
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
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            object[] ListOfCars = new object[6]
            {
                 new Car(231,"Volvo","qr",2003,"red",3000,5813),
                 new Car(698,"Reno","b1",2014,"black",3700,2791),
                 new Car(471,"Reno","mk",2006,"silver",2900,3861),
                 new Car(175,"bmw",1996),
                 new Car(943,"Maz","xx",2000,"pink",9999,1639),
                 new Car(308,"Volvo","s+",2016,"blue",4300,2601),
             };
            Car.sizeinfo();
            Console.WriteLine("Список автомобилей Volvo:");
            foreach(Car marks in ListOfCars)
            {
                if (marks.MARK == "Volvo")
                    Console.WriteLine(marks.ID +"\t" + marks.MARK +"\t"+ marks.YEAR);
            }
          
            int q = 18; 
            Console.WriteLine("Список автомобилей старше 18 лет:");
            foreach (Car marks in ListOfCars)
            {
                if (marks.YEAR < (2019-q))
                    Console.WriteLine(marks.ID +"\t"+ marks.MARK + "\t" + marks.COST );
            }

            var user = new { Name = "dddd" };
            Console.WriteLine(user.Name);
            Console.WriteLine(Equals(ListOfCars[0], ListOfCars[1]));
            Console.WriteLine(ListOfCars.Equals(ListOfCars));
            Console.ReadLine();
        }
    }
}
