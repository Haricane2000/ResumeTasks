using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    public interface IAnotherInterface
    {
        string ToString();
    }
    public interface IInterface
    {
        bool Equals(object obj);
        string ToString();
    }

    public abstract class Base
    {
        public struct Info
        {
            public int price;
        }
        public Info info = new Info();
    }

    class Product : Base, IAnotherInterface, IInterface
    {
        public string OrganizationName { get; set; }
        public string ProductName { get; set; }

        public Product()
        {
            OrganizationName = "NoName organization";
            ProductName = "NoName product";
        }

        public Product(string organization, string product, int price)
        {
            OrganizationName = organization;
            ProductName = product;
            info.price = price;
        }

        public override bool Equals(object obj)
        {
            Product product = (Product)obj;
            return ((this.OrganizationName == product.OrganizationName) && (this.ProductName == product.ProductName));
        }

        public override int GetHashCode()
        {
            return this.OrganizationName.GetHashCode() + this.ProductName.GetHashCode();
        }

        public override string ToString()
        {
            return this.OrganizationName + " " + this.ProductName;
        }
    }

    class Sweets : Product, IAnotherInterface, IInterface
    {
        public string SweetsTypeName { get; set; }
        public Sweets() : base()
        {
            SweetsTypeName = "NoName SweetsType";
        }

        public Sweets(string organization, string product, string SweetsType, int price) : base(organization, product, price)
        {
            SweetsTypeName = SweetsType;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.SweetsTypeName;
        }
    }

    abstract class Cakes : Sweets, IAnotherInterface, IInterface
    {
        public string Cream { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Cream;
        }

        public Cakes() : base()
        {
            Cream = "NoName Cream";
        }

        public Cakes(string organization, string product, string SweetsType, string cream, int price) : base(organization, product, SweetsType, price)
        {
            Cream = cream;
        }

        public abstract string MyFunc();
    }

    sealed class Candys : Sweets, IAnotherInterface, IInterface
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

        public Candys(string organization, string product, string SweetsType, string inc, int price) : base(organization, product, SweetsType, price)
        {
            Filling = inc;
        }
    }

    class Clocks : Product, IAnotherInterface, IInterface
    {
        public string DocType { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.DocType;
        }

        public Clocks() : base()
        {
            DocType = "NoName DocType";
        }

        public Clocks(string organization, string product, string SweetsType, string doc, int price) : base(organization, product, price)
        {
            DocType = doc;
        }
    }

    class Flower : Cakes, IAnotherInterface, IInterface
    {
        public string Resolution { get; set; }
        public override string MyFunc()
        {
            return "Переопределение";
        }

        public Flower(string organization, string product, string SweetsType, string cream, string res, int price) : base(organization, product, SweetsType, cream, price)
        {
            Resolution = res;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Resolution;
        }
    }
}