using System;

namespace ConsoleApp1
{
    interface IMyInterface
    {
        string MyFunc();
    }

    interface IAnotherInterface
    {
        string ToString();
    }

    partial class Product : Base, IAnotherInterface
    {
        public string OrganizationName { get; set; }
        public string ProductName { get; set; }

        public Product()
        {
            OrganizationName = "NoName organization";
            ProductName = "NoName product";
        }

        public Product(string organization, string product, int price, int mas)
        {
            OrganizationName = organization;
            ProductName = product;
            info.price = price;
            info.mas = mas;
        }

       
    }

    class Sweets : Product, IAnotherInterface
    {
        public string SweetsType { get; set; }
        public Sweets() : base()
        {
            SweetsType = "NoName SweetsType";
        }

        public Sweets(string organization, string product, string sweetstype, int price, int mas) : base(organization, product, price, mas)
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

        public Cakes(string organization, string product, string SweetsType, string cream, int price, int mas) : base(organization, product, SweetsType, price, mas)
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

        public Candys(string organization, string product, string manufacturer, string inc, int price, int mas) : base(organization, product, manufacturer, price, mas)
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

        public Clocks(string organization, string product, string manufacturer, string ctech, int price, int mas) : base(organization, product, price, mas)
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


    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("123", "213", 100, 500);
            Sweets nyam = new Sweets("456", "789", "456789", 200, 1300);
            Flower rose = new Flower();
            Gift gift = new Gift(10);
            rose.info.price = 300;
            IAnotherInterface[] arr = new IAnotherInterface[3];
            arr[0] = product;
            arr[1] = nyam;
            arr[2] = rose;

            try
            {
                Gift WrongLab = new Gift(100);
                WrongLab.Del(rose);
                //arr[4].ToString();
                gift.Add(product);
                gift.Add(nyam);
                gift.Add(rose);
                gift.Add(new Sweets());
                gift.Add(new Clocks());
                gift.Add(new Product());
                //lab.Add(new Product());


                gift.show();
                controller.show(gift);
                controller.sort(gift);
                gift.show();
                gift.Del(rose);
                //lab.Del(scanner);
                gift.show();
            }
            catch (LabIsFull ex)
            {
                Console.WriteLine("GiftIsFull Exception");
                Console.WriteLine(ex.Message);
            }
            catch (ElementDoesNotExist ex)
            {
                Console.WriteLine("ElementDoesNotExist Exception");
                Console.WriteLine(ex.Message);
            }
            catch (LabIsEmpty ex)
            {
                Console.WriteLine("GiftIsEmpty Exception");
                Console.WriteLine(ex.Message);
            }
            catch (WrongSize ex)
            {
                Console.WriteLine("WrongSize Exception");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Another Exception");
                Console.WriteLine(ex.Message);
            }


        }
    }
}