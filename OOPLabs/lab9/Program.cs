using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            void show(Programists[] array)
            {
                Console.WriteLine("Mutation level:");
                foreach (Programists x in array)
                {
                    if (x.MutLev < 0)
                    {
                        Console.WriteLine($"{x.Name} is deleted!");
                    }
                    else Console.WriteLine($"{x.Name} mutation level {x.MutLev}");
                }
                Console.WriteLine();
            }

            ProgCont contr = new ProgCont();
            Programists[] norm = new Programists[4];
            norm[0] = new Programists(5, 2);
            norm[1] = new Programists(5, 1);
            norm[2] = new Programists(3);
            norm[3] = new Programists(4);

          

            show(norm);
            contr.Mutation += norm[1].OnMutLev;
            contr.contr();
            show(norm);
            contr.Mutation += norm[3].OnMutLev;
            contr.Del+=norm[2].DeletePr;
            contr.contr();
            show(norm);

            priv hi = () => Console.WriteLine("Hello, it's delegates");
            summa summ = (x,y,z) => z<10? x + y:x*y;
            hi();
            Console.WriteLine(summ(4, 3,12));

            StringBuilder str = new StringBuilder("KSFV F S.eA Po");
            Action<StringBuilder> action;
            action = StringMethods.AddBAfterS;
            action += StringMethods.DeleteSpaces;
            action += StringMethods.AddSpacesAfterPoints;
            action += StringMethods.DeleteCommas;
            action += StringMethods.DeleteLetterA;

            action(str);
            Console.WriteLine($"{str}\n");
        }
    }
}