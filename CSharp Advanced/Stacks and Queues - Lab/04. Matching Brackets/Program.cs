using System;
using System.Collections;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    stack.Push(i);

                    int secondIndex = stack.Pop();
                    int firstIndex = stack.Pop();
                    int lenght = secondIndex - firstIndex + 1;

                    string content = input.Substring(firstIndex, lenght);
                    Console.WriteLine(content);
                }
            }
        }
    }
}
