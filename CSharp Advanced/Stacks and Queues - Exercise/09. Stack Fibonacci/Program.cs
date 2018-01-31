using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (long i = 1; i < n; i++)
            {
                long firstElement = stack.Pop();
                long secondElement = stack.Peek();
                long fib = firstElement + secondElement;
                stack.Push(firstElement);
                stack.Push(fib);
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
