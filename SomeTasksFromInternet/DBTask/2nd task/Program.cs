using System;

namespace _2nd_task
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppContext();
            
            Console.WriteLine("Holidays");
            Helper.Holidays(context);
            Console.WriteLine("Trainings");
            Helper.FinishTrainings(context);
            Console.WriteLine("Done");

        }
    }
}
