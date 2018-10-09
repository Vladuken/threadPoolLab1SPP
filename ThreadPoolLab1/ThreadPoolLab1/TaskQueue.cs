using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
namespace ThreadPoolLab1
{
    public class TaskQueue : IDisposable
    {
        private int taskCount;
        public delegate void TaskDelegate();
        private Queue<TaskDelegate> _tasks = new Queue<TaskDelegate>();
        private Thread[] threads;
        public TaskQueue(int ThreadCount)
        {
            taskCount = 0;
            threads = new Thread[ThreadCount];
            for(int i = 0; i < ThreadCount; i++)
            {
                threads[i] = new Thread(WorkingOnTasks) { IsBackground = true};
                threads[i].Start();
            }
        }

        private readonly object _lockObj = new object();
        void WorkingOnTasks()
        {
            while (true)
            {
                if (_tasks.Count > 0)
                {
                    TaskDelegate del = null;

                    lock (_tasks)
                    {
                        try
                        {
                            del = _tasks.Dequeue();
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e.Message);
                        }
                    }

                    if (del != null)
                    {
                        Console.WriteLine("Thread {0}: starting task", Thread.CurrentThread.ManagedThreadId);

                        var watch = System.Diagnostics.Stopwatch.StartNew();

                        del.Invoke();

                        watch.Stop();
                        var elapsedMs = watch.ElapsedMilliseconds;
                        
                        Console.WriteLine("Thread {0}: finished task in {1} ms", Thread.CurrentThread.ManagedThreadId, elapsedMs);
                        changeTaskCountBy(-1);
                    }
                }
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            _tasks.Enqueue(task);
            changeTaskCountBy(1);
        }

        private void changeTaskCountBy(int a)
        {
            taskCount += a;
        }

        public bool IsEmpty()
        {
            return _tasks.Count() == 0;
        }

        public bool AreTasksCompleted()
        {
            return taskCount == 0;
        }

        public void Dispose()
        {
            foreach(Thread thread in threads)
            {
                thread.Interrupt();
            }

        }
    }
}
