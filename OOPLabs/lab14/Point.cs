using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace lab
{
    [DataContract]
    class Point
    {
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
        public override string ToString() => $"Point: x = {X}, y = {Y};";
    }
}
