using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _10._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder stringBuilder = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(""); 

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string command = input[0];
                switch (command)
                {
                    case "1":
                        stack.Push(stringBuilder.ToString());
                        stringBuilder.Append(input[1]);
                        break;
                    case "2":
                        stack.Push(stringBuilder.ToString());
                        int length = int.Parse(input[1]);
                        stringBuilder.Remove(stringBuilder.Length - length, length);
                        break;
                    case "3":
                        int index = int.Parse(input[1]);
                        Console.WriteLine(stringBuilder[index - 1]);
                        break;
                    case "4":
                        stringBuilder.Clear();
                        stringBuilder.Append(stack.Pop());
                        break;
                }
            }
        }
    }
}
