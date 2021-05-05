using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace lab
{
    [Serializable, DataContract]
    public abstract class TVProgram : IProgram
    {
        [DataMember]
        int m_duration;
        [DataMember]
        public Author Author { get; set; }
        [DataMember]
        public bool ContainsAds { get; set; }
        [DataMember]
        public int Duration
        {
            get
            {
                return m_duration;
            }
            set
            {
                if (value < 0)
                    m_duration = 0;
                else
                    m_duration = value;
            }
        }

        public override string ToString()
        {
            return "TVProgram type";
        }

        public abstract void ShowProgram();
    }
}
