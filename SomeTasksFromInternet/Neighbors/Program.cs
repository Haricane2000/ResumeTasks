using System;
using System.Collections.Generic;
using System.IO;

namespace _2nd_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Point notFullPoint = new Point(5, 6);
            using Stream s = File.OpenRead("data.txt");
            var br = new PointReader(s);
            Console.WriteLine(NearestNeighbors.DetectClass(br.ReadFromStream(), notFullPoint,5));
        }
    }
}
