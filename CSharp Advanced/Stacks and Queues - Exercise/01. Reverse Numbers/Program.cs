using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            int length = stack.Count;
            
            for (int i = 0; i < length; i++)
            {           
                Console.Write(stack.Pop() + " ");
            }
        } 
    }
}
