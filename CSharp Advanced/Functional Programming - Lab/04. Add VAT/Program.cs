using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                    .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .Select(n => n * 1.2)
                    .ToList()
                    .ForEach(n => Console.WriteLine("{0:f2}", n));
        }
    }
}
