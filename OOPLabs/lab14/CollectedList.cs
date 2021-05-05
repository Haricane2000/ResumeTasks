using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace lab
{
    [CollectionDataContract(Name ="Холодиник")]
    class CollectedList<T> : List<T>
    {
    }
}
