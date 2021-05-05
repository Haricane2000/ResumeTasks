using System;
using System.IO;

namespace _8th_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using Stream s = File.OpenRead("data.csv");
            var br = new Filler(s);
            br.Fill();
        }
    }
}
