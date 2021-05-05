using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Lab15
{
    static class StaticClassBarrier
    {
        static Mutex Mutex = new Mutex();
        static Barrier Barrier = new Barrier(2);

        public static void WriteNumbers(object Info)
        {
            Mutex.WaitOne();
            int max = ((StartInfo)Info).n;
            int i;
            if (((StartInfo)Info).EvenOdd)
                i = 1;
            else
                i = 0;
            while (i < max)
            {
                StreamWriter NumWriter = new StreamWriter("numbersBarrier.txt");
                Console.WriteLine(i);
                NumWriter.WriteLine(i);
                Thread.Sleep(((StartInfo)Info).TimeOut);

                NumWriter.Close();
                if (((StartInfo)Info).b)
                    i += 2;
                else
                    i++;
            }
            Console.WriteLine();
            Mutex.ReleaseMutex();
        }
    }
}