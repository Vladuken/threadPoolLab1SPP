using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string source_dir, target_dir;
            try
            {
                CheckDirNames(args, out source_dir, out target_dir);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            /*
            TaskQueue taskQueue = new TaskQueue(4);
            foreach (Tuple<FileInfo, string> res in FileCopier.DirectoryCopyWithThreadPool(source_dir, target_dir, true))
            {
                FileInfo file = res.Item1;
                string path = res.Item2;
                taskQueue.EnqueueTask(() => { file.CopyTo(path, true); });
            }

            bool isRunning = true;
            while (isRunning)
            {
                if (taskQueue.AreTasksCompleted())
                {
                    System.Console.WriteLine("Tasks completed");
                    isRunning = false;
                }
                Thread.Sleep(10);
            } */

            //TaskQueue taskQueue = new TaskQueue(4);

            List<TaskQueue.TaskDelegate> lst = new List<TaskQueue.TaskDelegate>();

            foreach (Tuple<FileInfo, string> res in FileCopier.DirectoryCopyWithThreadPool(source_dir, target_dir, true))
            {
                FileInfo file = res.Item1;
                string path = res.Item2;
                lst.Add(() => { file.CopyTo(path, true); });
                //taskQueue.EnqueueTask(() => { file.CopyTo(path, true); });
            }

            Parallel.WaitAll(lst);

            System.Console.ReadLine();
        }

        private static void CheckDirNames(string[] args, out string source, out string dest)
        {
            if (args.Length < 2)
            {
                throw new Exception("Not enough arguments (" + args.Length + "). Usage: source directory name, target directory name.");
            }
            source = args[0];
            dest = args[1];
            if (source == dest)
            {
                throw new Exception("Source and destination directories should not coincide.");
            }
            if (!Directory.Exists(source))
            {
                throw new Exception("Source directory does not exist.");
            }
        }
    }
}
