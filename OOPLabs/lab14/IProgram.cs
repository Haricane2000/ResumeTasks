using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    interface IProgram
    {
        Author Author { get; set; }
        int Duration { get; set; }
        bool ContainsAds { get; set; }
        void ShowProgram();
    }
}
