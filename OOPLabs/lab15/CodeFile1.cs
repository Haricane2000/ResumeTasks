
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lab15
{
    static class StaticClass
    {
        public static void WriteNumbers(object n)
        {
            StreamWriter NumWriter = new StreamWriter("numbers.txt");

            for (int i = 0; i < (int)n; i++)
            {
                Console.WriteLine(i);
                NumWriter.WriteLine(i);
                Thread.Sleep(100);
            }

            NumWriter.Close();
        }
    }
}