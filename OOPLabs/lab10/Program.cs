using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Student student = new Student("name", "2");
            Dictionary<double, double> dictionary = new Dictionary<double, double>();
            Dictionary<double, Flower> TabletDictionary = new Dictionary<double, Flower>();
            Queue<double> queue = new Queue<double>();
            Queue<Flower> TabletQueue = new Queue<Flower>();
            Flower[] arr = new Flower[5];
            ObservableCollection<Flower> tablets = new ObservableCollection<Flower>();
            tablets.CollectionChanged += StaticClass.method;

            ArrayList list = new ArrayList(10)
            {
                10, 20, 30, 40, 50
            };
            list.Add("string");
            list.Add(student);
            list.RemoveAt(2);
            Console.WriteLine($"Nubmer of elements: {list.Count}");
            foreach (object x in list)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"List contains 30 = {list.Contains(30)}");
            Console.WriteLine();

            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());

            foreach (KeyValuePair<double, double> x in dictionary)
            {
                Console.WriteLine(x);
                queue.Enqueue(x.Value);
            }
            Console.WriteLine();

            foreach (double x in queue)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Flower();
                TabletDictionary.Add(arr[i].GetHashCode(), arr[i]);
            }
            Console.WriteLine();

            foreach (KeyValuePair<double, Flower> x in TabletDictionary)
            {
                Console.WriteLine(x);
                TabletQueue.Enqueue(x.Value);
            }
            Console.WriteLine();

            foreach (Flower x in TabletQueue)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            foreach (Flower x in arr)
            {
                tablets.Add(x);
            }
            tablets.RemoveAt(3);
            Console.WriteLine();
            foreach (Flower x in tablets)
            {
                Console.WriteLine(x);
            }
        }
    }
}
