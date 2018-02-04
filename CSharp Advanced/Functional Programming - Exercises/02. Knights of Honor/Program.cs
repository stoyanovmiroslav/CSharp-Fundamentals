using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = name => Console.WriteLine("Sir {0}", name);

            foreach (var name in names)
            {
                print(name);
            }

            //Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList()
            //    .ForEach(i => Console.WriteLine("Sir {0}", i));
        }
    }
}
