using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>(new List<string>());

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                List<string> commandArgs = input.Split().ToList();
                string command = commandArgs[0];

                switch (command)
                {
                    case "Create":
                        listyIterator.Create(commandArgs.Skip(1).ToList());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        Console.WriteLine(listyIterator.Print());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", listyIterator));
                        break;
                }
            }
        }
    }
}