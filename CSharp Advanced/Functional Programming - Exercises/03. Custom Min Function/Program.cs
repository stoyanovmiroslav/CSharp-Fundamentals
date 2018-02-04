using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            Func<int[], int> takeMinNumber = n => n.Min();
            Console.WriteLine(takeMinNumber(numbers));                      
        }
    }
}
