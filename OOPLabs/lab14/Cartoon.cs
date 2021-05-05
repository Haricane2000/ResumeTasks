using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace lab
{
    [Serializable, DataContract]
    public sealed class Cartoon : TVProgram
    {
        public override void ShowProgram()
        {
            Console.WriteLine("Showing cartoon...");
        }
        public override string ToString()
        {
            return "This is a cartoon program";
        }
    }
}
