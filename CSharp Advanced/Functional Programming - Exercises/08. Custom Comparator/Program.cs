using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToList().ForEach(n => Console.Write($"{n} "));
            numbers.Where(n => n % 2 != 0).OrderBy(n => n).ToList().ForEach(n => Console.Write($"{n} "));
        }
    }
}
