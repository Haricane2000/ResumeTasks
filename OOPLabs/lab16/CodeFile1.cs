using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ConsoleApp1
{
    class TaskMy
    {
        private static int ProductCount = 0;
        private static BlockingCollection<string> products = new BlockingCollection<string>();

        private static void PutProduct()
        {
            int NumOfProducts = 2;
            for (int i = 0; i < NumOfProducts; i++)
            {
                products.Add("product " + ProductCount);
                Console.WriteLine($"Product {ProductCount++} added");
            }
        }

        private static void GetProduct()
        {
            while (!products.IsCompleted)
            {
                Console.WriteLine($"Consumer takes {products.Take()}");
            }
        }

        public static void Start()
        {
            Task[] users = new Task[]
            {
                    Task.Factory.StartNew(PutProduct),
                    Task.Factory.StartNew(PutProduct),
                    Task.Factory.StartNew(PutProduct),
                    Task.Factory.StartNew(PutProduct),
                    Task.Factory.StartNew(PutProduct)
            };
            Task[] consumers = new Task[]
            {
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct),
                    Task.Factory.StartNew(GetProduct)
            };

            Task.WaitAll(consumers);
        }
    }
}