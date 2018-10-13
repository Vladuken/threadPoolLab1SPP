using System;
using System.Threading;

namespace Mutex
{
    class Program
    {
        public static Mutex mtx;
        public static int secretNumber;
        public static bool isGuessed = false;
        static void Main(string[] args)
        {
            secretNumber = new Random().Next() % 10;
            Console.WriteLine("SECRET NUMBER IS {0}", secretNumber);
            
            Thread.Sleep(10);
            mtx = new Mutex();
            StartThreads();
            Console.ReadLine();
        }

        public static void StartThreads()
        {
            Thread thr1 = new Thread(guess);
            Thread thr2 = new Thread(guess);
            Thread thr3 = new Thread(guess);
            thr1.Start();
            Thread.Sleep(100);
            thr2.Start();
            Thread.Sleep(100);
            thr3.Start();
        }

        public static void guess()
        {
            Random rnd = new Random();
            while (!isGuessed)
            {
                SetConsoleColor(Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine();
                Console.WriteLine("Thread {0} is waiting for mutex...", Thread.CurrentThread.ManagedThreadId);
                mtx.Lock();
                int number = rnd.Next() % 10;
                Console.WriteLine("     Thread {0} has guessed number {1}", Thread.CurrentThread.ManagedThreadId,number);

                if(number == secretNumber)
                {
                    Console.WriteLine("         It is correct number!!!");
                    Console.WriteLine("                             \t\tThread {0} wins", Thread.CurrentThread.ManagedThreadId);
                    isGuessed = true;
                }
                else
                {
                    Console.WriteLine("             It is incorrect number!!!");
                }
                Console.WriteLine("Thread {0} is released by mutex...", Thread.CurrentThread.ManagedThreadId);

                mtx.Unlock();
                Thread.Sleep(1000);
            }
        }

        public static void SetConsoleColor(int a)
        {
            Console.BackgroundColor = (ConsoleColor) a;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}