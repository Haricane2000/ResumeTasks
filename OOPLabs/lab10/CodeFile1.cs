using System;

namespace ConsoleApp1
{
   
    class Product : IAnotherInterface
    {
        public string OrganizationName { get; set; }
        public string ProductName { get; set; }

        public Product()
        {
            OrganizationName = "NoName organization";
            ProductName = "NoName product";
        }

        public Product(string organization, string product)
        {
            OrganizationName = organization;
            ProductName = product;
        }

        public override bool Equals(object obj)
        {
            Product product = (Product)obj;
            return ((this.OrganizationName == product.OrganizationName) && (this.ProductName == product.ProductName));
        }

        public override int GetHashCode()
        {
            Random rand = new Random();
            int a;
            a = rand.Next(1,100);
            return this.OrganizationName.GetHashCode() + this.ProductName.GetHashCode()+a.GetHashCode();
        }

        public override string ToString()
        {
            return this.OrganizationName + " " + this.ProductName;
        }
    }

    class Sweets : Product, IAnotherInterface
    {
        public string SweetsType { get; set; }
        public Sweets() : base()
        {
            SweetsType = "NoName SweetsType";
        }

        public Sweets(string organization, string product, string sweetstype) : base(organization, product)
        {
            SweetsType = sweetstype;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.SweetsType;
        }
    }

    abstract class Cakes : Sweets, IAnotherInterface
    {
        public string Cream { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Cream;
        }

        public Cakes() : base()
        {
            Cream = "NoName cream";
        }

        public Cakes(string organization, string product, string SweetsType, string cream) : base(organization, product, SweetsType)
        {
            Cream = cream;
        }

        public abstract string MyFunc();
    }

    sealed class Candys : Sweets, IAnotherInterface
    {
        public string Filling { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Filling;
        }

        public Candys() : base()
        {
            Filling = "NoName Filling";
        }

        public Candys(string organization, string product, string manufacturer, string inc) : base(organization, product, manufacturer)
        {
            Filling = inc;
        }
    }

    class Clocks : Product, IAnotherInterface
    {
        public string ClockTech { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.ClockTech;
        }

        public Clocks() : base()
        {
            ClockTech = "NoName cTech";
        }

        public Clocks(string organization, string product, string manufacturer, string ctech) : base(organization, product)
        {
            ClockTech = ctech;
        }
    }

    class Flower : Cakes, IMyInterface, IAnotherInterface
    {
        public string Resolution { get; set; }
        public override string MyFunc()
        {
            return "Переопределение";
        }
        string IMyInterface.MyFunc()
        {
            return "Реализация метода интерфейса";
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Resolution;
        }
    }

    class Print
    {
        public static void IAmPrinting(IAnotherInterface obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

}