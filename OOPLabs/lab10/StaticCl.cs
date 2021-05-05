using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ConsoleApp1
{
    static class StaticClass
    {
        public static void method(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Our collection changed!");
        }
    }
}