using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lab15
{
    class StartInfo
    {
        public int n;
        public int TimeOut;
        public bool EvenOdd = false;
        public bool b = false;

        public StartInfo(int _n, int _TimeOut, bool _EvenOdd)
        {
            n = _n;
            TimeOut = _TimeOut;
            EvenOdd = _EvenOdd;
        }

        public StartInfo(int _n, int _TimeOut, bool _EvenOdd, bool _b)
        {
            n = _n;
            TimeOut = _TimeOut;
            EvenOdd = _EvenOdd;
            b = _b;
        }
    }

    static class StaticClassMutex
    {
        static Mutex Mutex = new Mutex();

        public static void WriteNumbers(object Info)
        {

            int max = ((StartInfo)Info).n;
            int i;
            if (((StartInfo)Info).EvenOdd)
                i = 1;
            else
                i = 0;
            while (i < max)
            {
                Mutex.WaitOne();
                {
                    StreamWriter NumWriter = new StreamWriter("numbers.txt");
                    Console.WriteLine(i);
                    NumWriter.WriteLine(i);
                    Thread.Sleep(((StartInfo)Info).TimeOut);
                    NumWriter.Close();
                }
                Mutex.ReleaseMutex();
                if (((StartInfo)Info).b)
                    i += 2;
                else
                    i++;
            }
            Console.WriteLine();
        }
    }
}