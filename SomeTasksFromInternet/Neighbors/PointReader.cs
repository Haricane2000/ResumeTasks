using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _2nd_task
{
    public class PointReader
    {
        private readonly Stream _stream;
        public PointReader(Stream stream)
        {
            _stream = stream ?? throw new ArgumentNullException();
        }

        public List<Point> ReadFromStream()
        {
            StreamReader sr = new StreamReader(_stream);

            List<string> str = new List<string>();
            List<Point> pointList = new List<Point>();
            int c = 0;

            while (!sr.EndOfStream)
            {
                str.Add(sr.ReadLine());
                c++;
            }
            
            Parallel.ForEach(str, CreateObject);

            void CreateObject(string str)
            {
                string[] point = str.Split(',');
                
                pointList.Add(new Point(point[0],
                    double.Parse(point[1].Replace('.', ',')),
                    double.Parse(point[2].Replace('.', ','))));
            }
            
            return pointList;
        }
    }
}