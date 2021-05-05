using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2nd_task
{
    public class NearestNeighbors
    {
        public static string DetectClass(List<Point> points, Point unknownPoint, int k)
        {

            if (points == null)
                throw new ArgumentNullException();
            if (unknownPoint == null)
                throw new ArgumentNullException();
            if (k < 0)
                throw new ArgumentException();

            var syncObject = new object();
            int count = 0;
            List<(string, double)> distantion = new List<(string, double)>();
            
            Parallel.ForEach(points, CalcDistance);

            void CalcDistance(Point point)
            {
                if (point == null)
                    throw new ArgumentNullException();
                lock (syncObject)
                {
                    distantion.Add((point.name, Math.Sqrt(Math.Pow((unknownPoint.x - point.x), 2) + Math.Pow((unknownPoint.y - point.y), 2))));
                }
            }

            var result = distantion.OrderBy(x => x.Item2).Select(x => x.Item1).Take(k);


            foreach (var a in result)
            {
                if (a == "grapefruit")
                {
                    count++;
                }
            }

            if (count > k / 2)
            {
                return "grapefruit";
            }
            return "orange";
        }

    }
}
