using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Programists
    {
        static int count = 0;
        public int MutLev = 0;
        public int MaxMutLev = 5;
        public string Name;
        

        public Programists()
        {
            Name = "Programists " + count++;
            MutLev = 1;
            MaxMutLev = 5;
        }

        public Programists(int lv)
        {
            Name = "Programists " + count++;
            MutLev = lv;
        }

        public Programists(int max, int lv) : this(lv)
        {
            MaxMutLev = max;
        }

        ~Programists()
        {
            count--;
        }

        public void OnMutLev(object sender, EventArgs e)
        {
            int levup = 1;
            Console.WriteLine($"{Name} mutation level + {levup}");
            if (MutLev + levup >= MaxMutLev)
                MutLev = MaxMutLev;
            else
                MutLev += levup;
        }

        public void DeletePr(object sender, EventArgs e)
        {
            
            Console.WriteLine($"{Name} programist deleted ");
            MutLev -= 9999;
            if (MutLev < 0)
            {
                
                Console.WriteLine($"{Name} is delete!");
            }
        }
    }
}