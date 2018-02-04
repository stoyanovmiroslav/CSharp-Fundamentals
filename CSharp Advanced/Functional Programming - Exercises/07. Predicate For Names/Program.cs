using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, bool> correctName = n => n.Length <= length;
            names.Where(correctName).ToList().ForEach(n => Console.WriteLine($"{n}"));
        }
    }
}
