using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var charArray = input.Split(' ');
            var stack = new Stack<string>(charArray.Reverse());

            while (stack.Count > 1)
            {
                int leftOperant = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int rightOperant = int.Parse(stack.Pop());
                int result = 0;

                switch (operation)
                {
                    case "-": result = leftOperant - rightOperant; break;  
                    case "+": result = leftOperant + rightOperant; break;
                }
                stack.Push(result.ToString());
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
