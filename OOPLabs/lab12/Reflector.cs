using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace ConsoleApp1
{
    class Reflector
    {
        public static Type GetTypeByString(string name)
        {
            return Type.GetType("ConsoleApp1." + name);
        }

        public static void ToFile(string ClassName, string name)
        {
            StreamWriter writer = new StreamWriter(@"D:\Univer\2 курс\ООП\" + name + ".txt");
            Type t1 = GetTypeByString(ClassName);
            writer.WriteLine($"Класс {t1.Name}");
            writer.WriteLine("Конструкторы:");
            foreach (var x in t1.GetConstructors())
            {
                writer.WriteLine(x);
            }
            writer.WriteLine("Методы:");
            foreach (var x in t1.GetMethods())
            {
                writer.WriteLine(x);
            }
            writer.WriteLine("Поля:");
            foreach (var x in t1.GetFields())
            {
                writer.WriteLine(x);
            }
            writer.Close();
        }

        public static void GetPublicMethods(string ClassName)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Public методы класса {t.Name}:");
            foreach (var x in t.GetMethods())
            {
                if (x.IsPublic)
                    Console.WriteLine(x);
            }
            Console.WriteLine();
        }

        public static void GetField(string ClassName)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Поля и свойства класса {t.Name}");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }

        public static void GetInterfaces(string ClassName)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Интерфейсы класса {t.Name}");
            foreach (var x in t.GetInterfaces())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }

        public static void GetMethodsByParam(string ClassName, string param)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Методы класса {t.Name} с параметром {param}");
            foreach (var x in t.GetMethods())
            {
                foreach (var y in x.GetParameters())
                {
                    if (y.ParameterType.ToString() == param)
                        Console.WriteLine(x);
                }
            }
            Console.WriteLine();
        }

        public static void CallMethodFromFile(string ClassName, string MethodName)
        {
            StreamReader reader = new StreamReader(@"D:\Univer\2 курс\ООП\params.txt");
            List<string> param = new List<string>();
            while (!reader.EndOfStream)
            {
                param.Add(reader.ReadLine());
            }
            foreach (var x in GetTypeByString(ClassName).GetMethods())
            {
                if (x.Name == MethodName)
                {
                    x.Invoke(null, param.ToArray());
                }
            }

            reader.Close();
        }
    }
}