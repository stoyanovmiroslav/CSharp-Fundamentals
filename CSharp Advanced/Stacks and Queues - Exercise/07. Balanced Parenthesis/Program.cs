using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charArray = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();
            char[] parenthesisOpen = { '{', '(', '[' };
            char[] parenthesisClose = { '}', ')', ']' };

            for (int i = 0; i < charArray.Length; i++)
            {
                char currentSymbol = charArray[i];
                
                if (parenthesisClose.Contains(currentSymbol))
                {
                    if (stack.Count == 0)
                    {
                        PrintNoAndExit();
                    }
                    int openIndex = Array.IndexOf(parenthesisOpen, stack.Peek());
                    int closeIndex = Array.IndexOf(parenthesisClose, currentSymbol);
                    if (openIndex == closeIndex)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        PrintNoAndExit();
                    }
                }
                else
                {
                    stack.Push(currentSymbol);
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
        }

        private static void PrintNoAndExit()
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }
    }
}
