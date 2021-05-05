using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1
{

    class SKRLog
    {
        private string path;
        private StreamWriter writer;
        private FileSystemWatcher watcher;

        public SKRLog(string _path)
        {
            path = _path;
            writer = new StreamWriter(path);
            watcher = new FileSystemWatcher(@"D:\");

            watcher.Changed += new FileSystemEventHandler(OnChange);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChange(object source, FileSystemEventArgs e)
        {
            writer.WriteLine($"[{DateTime.Now}] {e.FullPath} {e.ChangeType}");
        }

        public void close()
        {
            writer.Close();
            watcher.EnableRaisingEvents = false;
        }

        public void GetInMinute(string _path)
        {
            StreamReader reader = new StreamReader(path);
            StreamWriter writer = new StreamWriter(_path);
            List<string> list = new List<string>();
            List<string> FinalList = new List<string>();

            while (!reader.EndOfStream)
            {
                list.Add(reader.ReadLine());
            }

            writer.WriteLine($"Length of log file: {list.Count}");

            foreach (string x in list)
            {
                if (x.Substring(15, 2) == DateTime.Now.Minute.ToString())
                    FinalList.Add(x);
            }

            foreach (string x in FinalList)
            {
                writer.WriteLine(x);
            }

            reader.Close();
            writer.Close();
        }
    }

    class SKRDiskInfo
    {
        public static void ShowFreeSpace()
        {
            var AllDrives = DriveInfo.GetDrives();
            foreach (var x in AllDrives)
            {
                if (x.IsReady)
                {
                    Console.WriteLine($"Drive name: {x.Name}");
                    Console.WriteLine($"Available space: {x.AvailableFreeSpace}");
                    Console.WriteLine();
                }
            }
        }

        public static void ShowFileSystem()
        {
            var AllDrives = DriveInfo.GetDrives();
            foreach (var x in AllDrives)
            {
                if (x.IsReady)
                {
                    Console.WriteLine($"Drive name: {x.Name}");
                    Console.WriteLine($"File system: {x.DriveFormat}");
                    Console.WriteLine();
                }
            }
        }

        public static void ShowDiskInfo()
        {
            var AllDrives = DriveInfo.GetDrives();
            foreach (var x in AllDrives)
            {
                if (x.IsReady)
                {
                    Console.WriteLine($"Drive name: {x.Name}");
                    Console.WriteLine($"Dirve size: {x.TotalSize}");
                    Console.WriteLine($"Dirve total free space: {x.TotalFreeSpace}");
                    Console.WriteLine($"Dirve volume label: {x.VolumeLabel}");
                    Console.WriteLine();
                }
            }
        }
    }

    class SKRFileInfo
    {
        public static void ShowFullPath(string path)
        {
            if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                Console.WriteLine($"Full path to file: {file.FullName}");
                Console.WriteLine();
            }
            else
            {
                throw new Exception("There is no such file!!");
            }
        }

        public static void ShowFileInfo(string path)
        {
            if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                Console.WriteLine($"Full path to file: {file.FullName}");
                Console.WriteLine($"File name: {file.Name}");
                Console.WriteLine($"File size: {file.Length}");
                Console.WriteLine($"File extention: {file.Extension}");
                Console.WriteLine($"File creation time: {file.CreationTime}");
                Console.WriteLine();
            }
            else
            {
                throw new Exception($"File {path} does not exists!!!");
            }
        }
    }
    class SKRDirInfo
    {
        public static void ShowDirInfo(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo info = new DirectoryInfo(path);
                Console.WriteLine($"Directory name: {info.Name}");
                Console.WriteLine($"Directory path: {info.FullName}");
                Console.WriteLine($"Directory creation time: {info.CreationTime}");
                Console.WriteLine($"Number of files: {info.GetFiles().Length}");
                Console.WriteLine($"Number of subdirectories: {info.GetDirectories().Length}");
                Console.WriteLine();
            }
            else
            {
                throw new Exception($"Directory {path} does not exists!!!");
            }
        }
    }

  

    class SKRFileManager
    {
        public static void MethodOne(string path)
        {
            DirectoryInfo disk = new DirectoryInfo(@"D:\");
            var directory = Directory.CreateDirectory(path);
            StreamWriter writer = new StreamWriter(path + @"SKRdirinfo.txt");
            writer.WriteLine("Files:");
            foreach (var x in disk.GetFiles())
            {
                writer.WriteLine(x.FullName);
            }
            writer.WriteLine("\nDirectories:");
            foreach (var x in disk.GetDirectories())
            {
                writer.WriteLine(x.Name);
            }
            writer.WriteLine();
            writer.Close();
        }

        public static void CopyDir(string path1, string path2)
        {
            if (Directory.Exists(path1))
            {
                DirectoryInfo dir1 = new DirectoryInfo(path1);
                DirectoryInfo dir2 = Directory.CreateDirectory(path2);

                foreach (var x in dir1.GetFiles())
                {
                    x.CopyTo(dir2.FullName + @"\" + x.Name);
                }
            }
            else
            {
                throw new Exception("There is no such directory!!!");
            }
        }
    }
}