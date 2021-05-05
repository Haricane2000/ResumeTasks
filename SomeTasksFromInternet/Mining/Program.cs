using System;
using System.Numerics;
using System.Threading;

namespace _6th_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //// посчитаем факториал обычной функцией
            //BigInteger number = 12912839123182;
            //var f1 = Mining.Factorization(number);
            //// Console.WriteLine(f);
            //Console.WriteLine("Normal: done");

            //// теперь используем асинхронную версию
            //var task = Mining.FactorizationAsync(number);

            //// готово?
            //Console.WriteLine($"Ready? {task.IsCompleted}");

            //// поработаем... (поставьте другие значения - 1000, 4000)
            //Thread.Sleep(5000);

            //// а теперь готово?
            //Console.WriteLine($"Ready? {task.IsCompleted}");

            //// вот сейчас точно будет готово
            //var f2 = task.Result;
            //Console.WriteLine("Async: done");
            //Console.WriteLine($"Is OK? {f1 == f2} ");

            //foreach (var a in f1)
            //{
            //    Console.WriteLine(a);
            //}

            //foreach (var a in f2)
            //{
            //    Console.WriteLine(a);
            //}

            //Console.ReadLine();

            BigInteger num1 = -17;
            BigInteger num2 = 15;

            foreach (var a in Mining.Factorization(num1))
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine("SEC");
            foreach (var a in Mining.Factorization(num2))
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine("NOD");
            Console.WriteLine(Mining.CalculateGcd(num1, num2).Result);
        }
    }
}
