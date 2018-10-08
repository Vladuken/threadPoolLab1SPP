using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskQueue taskQueue = new TaskQueue(5);

            for(int i = 0; i < 1000; i++)
            {
                if (i % 6 <= 3) {
                    taskQueue.EnqueueTask(Tasks.SleepForSec);
                }
                else if(i % 6 == 4)
                {
                    taskQueue.EnqueueTask(Tasks.SleepForTenSec);
                }
                else
                {
                    taskQueue.EnqueueTask(Tasks.Task1);
                }
            }
        }
    }
}
