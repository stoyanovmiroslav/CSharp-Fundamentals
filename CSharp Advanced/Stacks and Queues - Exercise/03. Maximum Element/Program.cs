using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> stackMax = new Stack<int>();
            stackMax.Push(0);



            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (command[0] == 1)
                {
                    stack.Push(command[1]);

                    if (command[1] > stackMax.Peek())
                    {
                        stackMax.Push(command[1]);
                    }
                }
                else if(command[0] == 2)
                {
                    if (stack.Pop() == stackMax.Peek())
                    {
                        stackMax.Pop();
                    }
                    
                }
                else if (command[0] == 3)
                {
                    Console.WriteLine(stackMax.Peek());
                }
            }
        }
    }
}
