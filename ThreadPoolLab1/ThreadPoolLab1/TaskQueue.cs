using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
namespace ThreadPoolLab1
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();
        private Queue<TaskDelegate> _tasks = new Queue<TaskDelegate>();
        private Thread[] threads;
        public TaskQueue(int ThreadCount)
        {
            threads = new Thread[ThreadCount];
            for(int i = 0; i < ThreadCount; i++)
            {
                threads[i] = new Thread(WorkingOnTasks);
                threads[i].Start();
            }
        }

        private readonly object _lockObj = new object();
        private int taskcount = 0;
        void WorkingOnTasks()
        {
            while (true)
            {
                //lock (_lockObj)
                //{
                    if (_tasks.Count > 0)
                    {
                        lock(_lockObj) Console.WriteLine("Thread {0}: starting task", Thread.CurrentThread.ManagedThreadId,taskcount);

                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        // the code that you want to measure comes here
                        

                        _tasks.Dequeue()?.Invoke();
                        watch.Stop();
                        var elapsedMs = watch.ElapsedMilliseconds;
                    lock (_lockObj)
                        {
                            Console.WriteLine("Thread {0}: finished task in {1} ms", Thread.CurrentThread.ManagedThreadId,elapsedMs);
                            taskcount++;
                        }
                        
                    //Thread.Sleep(1000);
                }
                //}
            }
                
        }

        public void EnqueueTask(TaskDelegate task)
        {
            _tasks.Enqueue(task);
        }
    }
}
