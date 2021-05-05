using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private const int maxNum = 100000;
        private static CancellationTokenSource source = new CancellationTokenSource();
        private static CancellationToken token = source.Token;
        private const int num1 = 150;
        private const int num2 = 72;
        private const int num3 = 963;



        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Task task;

            //Task 1
            for (int i = 0; i < 3; i++)
            {
                stopwatch.Start();
                task = Task.Factory.StartNew(FindSimpleNumber);
                Console.WriteLine($"\nЗадача {i}. ID: {task.Id.ToString()}");
                Console.WriteLine($"\nЗадача {i}. статус: {task.Status.ToString()}");
                task.Wait();
                stopwatch.Stop();
                Console.WriteLine($"\nВремя выполнения задачи {i}: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n");
                stopwatch.Reset();
            }

            Thread.Sleep(5000);

            //Task 2
            stopwatch.Start();
            task = Task.Factory.StartNew(FindSimpleNumber);
            Console.WriteLine($"\nID задачи: {task.Id.ToString()}");
            Console.WriteLine($"\nСтатус задачи: {task.Status.ToString()}");
            Console.WriteLine("q - для выхода ");
            if (Console.ReadKey().KeyChar == 'q')
                source.Cancel();
            task.Wait();
            stopwatch.Stop();
            Console.WriteLine($"\nВремя выполнения задачи: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n");

            Thread.Sleep(1000);

            //Task 3, 4
            task3();
            //Task 5

            Random random = new Random(10000);
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                int[] arr = new int[10000000];
                for (int j = 0; j < arr.Length; j++)
                    arr[j] = random.Next();
            }
            stopwatch.Stop();
            Console.WriteLine($"\nВремя выполнения: {stopwatch.Elapsed.TotalMilliseconds.ToString()}");
            stopwatch.Reset();

            stopwatch.Start();
            Parallel.For(0, 10, (count) =>
            {
                int[] arr = new int[10000000];
                Parallel.ForEach(arr, (el) =>
                {
                    el = random.Next();
                });
            });
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n");
            stopwatch.Reset();

            //Task 6
            void func()
            {
                for (int i = 0; i < 10; i++)
                {
                    int[] arr = new int[1000000];
                    for (int j = 0; j < arr.Length; j++)
                        arr[j] = random.Next();
                }
                Console.WriteLine("Func() done!");
            }

            stopwatch.Start();
            Parallel.Invoke(func, func, func);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.Elapsed.TotalMilliseconds.ToString()}");
            stopwatch.Reset();

            stopwatch.Start();
            func();
            func();
            func();
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n");
            stopwatch.Reset();

            //Task 7
            TaskMy.Start();
        }

        private static void FindSimpleNumber()
        {
            for (int i = 0; i < maxNum; i++)
            {
                if (IsSimpleNumber(i))
                    Console.Write($"{i}, ");
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Прервано\n");
                    return;
                }
            }
        }

        private static bool IsSimpleNumber(int number)
        {
            for (int i = 2; i < (number / 2); i++)
                if (number % i == 0)
                    return false;
            return true;
        }


        public static int func1()
        {
            Console.WriteLine($"Task1 completed. Result: {num1 * num2}");
            return num1 * num2;
        }
        private static int func2()
        {
            Console.WriteLine($"Task2 completed. Result: {num1 - num2}");
            return num1 - num2;
        }
        private static int func3()
        {
            Console.WriteLine($"Task3 completed. Result: {num3 + num2}");
            return num3 + num2;
        }

        private static async void task3()
        {
            //Task 3, 4
            Task<int> task1 = new Task<int>(func1);
            Task<int> task2 = new Task<int>(func2);
            Task<int> task3 = new Task<int>(func3);

            await task1.ContinueWith((t1) => Console.WriteLine($"Task1 Completed. Result: {t1.Result}"));
            await task2.ContinueWith((t2) => Console.WriteLine($"Task2 Completed. Result: {t2.Result}"));
            await task3.ContinueWith((t3) => Console.WriteLine($"Task3 Completed. Result: {t3.Result}"));

            task1.Start();
            task2.Start();
            task3.Start();

            var awaiter = task1.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine($"Task1 completed. Result: {awaiter.GetResult()}"));
        }
    }
}