using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length < 1)
            {
                throw new Exception("Not enough arguments (" + args.Length + "). Usage: dll or exe file");
            }


            string format = args[0].Split('.')[args.Length];

            if (format == "dll" || format == "exe")
            {
                Assembly file;
                try
                {
                    file = Assembly.LoadFile(args[0]);

                }
                catch (Exception e)
                {
                    throw new Exception("Error occured on file loading");
                   
                }
                Type[] arr = file.GetTypes();
                List<string> a = new List<string>();
                foreach(Type type in file.GetExportedTypes())
                {
                    if (type.IsPublic)
                    {
                        a.Add(type.FullName);
                    }
                }
                a.Sort();
                foreach(string l in a)
                {
                    System.Console.WriteLine(l);
                }
                
                Console.ReadKey();

            }
        }
    }
}
