using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolLab1
{
    static class Parallel
    {
        public static void WaitAll(List<ThreadPoolLab1.TaskQueue.TaskDelegate> lst)
        {
            TaskQueue taskQueue = new TaskQueue(5);
            foreach(var del in lst)
            {
                taskQueue.EnqueueTask(del);
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
            }
        }
    }
}
