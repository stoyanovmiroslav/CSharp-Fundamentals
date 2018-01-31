using System;
using System.Collections.Generic;

namespace _03._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (decimalNumber == 0)
            {
                stack.Push(0);
            }
            while (decimalNumber > 0)
            {
                int rest = decimalNumber % 2;
                decimalNumber /= 2;

                stack.Push(rest);
            }

            foreach (var item in stack)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
