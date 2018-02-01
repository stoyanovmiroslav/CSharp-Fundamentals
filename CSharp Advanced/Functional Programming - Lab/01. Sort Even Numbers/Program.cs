using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", number));
        }
    }
}
