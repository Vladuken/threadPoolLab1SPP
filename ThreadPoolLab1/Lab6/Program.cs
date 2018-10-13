using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> a1 = new DynamicList<int>();
            for(int i = 0; i < 30; i++)
            {
                a1.Add(i);
            }

            for (int i = 15; i < 20; i++)
            {
                a1.Remove(i);
            }

            a1.RemoveAt(0);

            foreach(var item in a1)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();

            DynamicList<string> a2 = new DynamicList<string>();
            a2.Add("aaa");
            a2.Add("bbb");
            a2.Add("ccc");
            a2.Remove("bbb");
            foreach(string item in a2)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();


            object a = 5;
            object b = "help";
            object c = true;
            object d = new Random();
            DynamicList<object> a3 = new DynamicList<object>();
            a3.Add(a);
            a3.Add(b);
            a3.Add(c);
            a3.Add(d);

            a3.Remove("help");

            foreach (object item in a3)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();




            System.Console.Read();
        }
    }
}
