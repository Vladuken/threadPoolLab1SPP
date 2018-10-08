using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolLab1
{
    static class Tasks
    {   
        public static void Task1()
        {
            Random rnd = new Random();

            double res = 0; 
            for(int i = 0; i < 10000000; i++)
            {
                res += rnd.NextDouble();
            }

        }

        public static void SleepForSec()
        {
            Thread.Sleep(1000);
        }
        public static void SleepForTenSec()
        {
            Thread.Sleep(10000);
        }

        public static void SleepForMinute()
        {
            Thread.Sleep(60000);
        }
    }
}
