using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerCallback tc = new TimerCallback(ShowTime);
            Timer timer = new Timer(tc, null, 0, 2000);
            //Processes
            var AllProcesses = Process.GetProcesses();
            StreamWriter writer = new StreamWriter("processes.txt");

            try
            {
                foreach (var x in AllProcesses)
                {
                    Console.WriteLine($"{x.Id} {x.ProcessName} {x.BasePriority} {x.StartTime} {x.UserProcessorTime}");
                    writer.WriteLine($"{x.Id} {x.ProcessName} {x.BasePriority} {x.StartTime} {x.UserProcessorTime}");
                }
            }
            catch (Exception ex) { }
            Console.WriteLine();
            writer.Close();

            //Domain
            Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName} {AppDomain.CurrentDomain.SetupInformation}");
            Console.WriteLine($"Assemblies:");
            foreach (var x in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine($"{x}");
            }

            //Thread
            StartInfo t1 = new StartInfo(100, 50, true, true);
            StartInfo t2 = new StartInfo(100, 100, false, true);
            StartInfo t = new StartInfo(100, 10, false);

            Thread th = new Thread(new ParameterizedThreadStart(StaticClassMutex.WriteNumbers));
            th.Name = th.ToString();
            th.Start(t);
            Thread.Sleep(1000);
            th.Suspend();
            Console.WriteLine($"{th.Name} {th.Priority} {th.ThreadState}");
            Thread.Sleep(2000);
            th.Resume();
            Thread.Sleep(1000);

            //Mutex
            Thread th1 = new Thread(new ParameterizedThreadStart(StaticClassMutex.WriteNumbers));
            Thread th2 = new Thread(new ParameterizedThreadStart(StaticClassMutex.WriteNumbers));
            th2.Start(t2);
            th1.Start(t1);
            Thread.Sleep(10000);
            th1 = new Thread(new ParameterizedThreadStart(StaticClassBarrier.WriteNumbers));
            th2 = new Thread(new ParameterizedThreadStart(StaticClassBarrier.WriteNumbers));
            th2.Start(t2);
            th1.Start(t1);
            Thread.Sleep(10000);

            //Timer
            void ShowTime(object obj)
            {
                Console.WriteLine("\nТекущее время: " + DateTime.Now.TimeOfDay + "\n");
            }
        }
    }
}