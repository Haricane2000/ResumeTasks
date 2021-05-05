using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SKRLog log = new SKRLog(@"D:\Log.txt");
                StreamWriter str;
                string str1;

                SKRDiskInfo.ShowFreeSpace();
                SKRDiskInfo.ShowFileSystem();
                SKRDiskInfo.ShowDiskInfo();

                SKRFileInfo.ShowFullPath(@"D:\Games\steam.exe");
                SKRFileInfo.ShowFullPath(@"D:\lab13\fale.txt");
                SKRFileInfo.ShowFileInfo(@"D:\Games\steam.exe");
                SKRFileInfo.ShowFileInfo(@"D:\lab13\fale.txt");

                SKRDirInfo.ShowDirInfo(@"D:\lab13");

                SKRFileManager.MethodOne(@"D:\SKRInspect\");
                SKRFileManager.CopyDir(@"D:\SKRInspect\", @"D:\SKRFile");

                str1 = Console.ReadLine();
                while (str1 != "q")
                {
                    str = new StreamWriter(@"D:\11.txt");
                    str.WriteLine(str1);
                    str1 = Console.ReadLine();
                    str.Close();
                }

                log.close();


                log.GetInMinute(@"D:\FinalLog.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}