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
                foreach(Type type in file.GetTypes())
                {
                    if (type.IsPublic)
                    {

                        MemberInfo[] members = type.GetMembers(BindingFlags.Public
                                          | BindingFlags.Instance
                                          | BindingFlags.Static);
                        //MemberInfo[] members = type.GetMembers(BindingFlags.Default);

                        foreach (MemberInfo member in members)
                        {
                            Console.WriteLine(type.FullName + "." + member.Name);
                        }

                        //System.Console.WriteLine(type.FullName);
                    }
                }

                Console.ReadKey();

            }
        }
    }
}
