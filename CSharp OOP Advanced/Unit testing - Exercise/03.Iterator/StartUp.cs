using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        ListIterator<string> listyIterator = new ListIterator<string>(new List<string>());

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
                    try
                    {
                        Console.WriteLine(listyIterator.Print());
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
            }
        }
    }
}