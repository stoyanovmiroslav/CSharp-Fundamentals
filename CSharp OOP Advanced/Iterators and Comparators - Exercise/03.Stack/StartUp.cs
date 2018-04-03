using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;
        CustomStack<string> stack = new CustomStack<string>();

        while ((input = Console.ReadLine()) != "END")
        {
            List<string> commandArgs = input.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = commandArgs[0];

            switch (command)
            {
                case "Push":
                    stack.Push(commandArgs.Skip(1).ToList());
                    break;
                case "Pop":
                    string element = stack.Pop();
                    if (element == null)
                    {
                        Console.WriteLine("No elements");
                    }
                    break;
            }
        }

        if (stack.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}