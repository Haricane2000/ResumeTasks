using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    [Serializable]
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Trophies { get; set; }
    }
}
