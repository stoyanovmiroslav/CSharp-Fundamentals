using System;
using System.Dynamic;

public class StartUp
{
    static void Main(string[] args)
    {
        string command = String.Empty;
        CustomList<string> myList = new CustomList<string>();

        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split();

            switch (commandArgs[0])
            {
                case "Add":
                    myList.Add(commandArgs[1]);
                    break;
                case "Remove":
                    myList.Remove(int.Parse(commandArgs[1]));
                    break;
                case "Contains":
                    Console.WriteLine(myList.Contains(commandArgs[1]));
                    break;
                case "Swap":
                    myList.Swap(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
                    break;
                case "Greater":
                    Console.WriteLine(myList.CountGreaterThan(commandArgs[1]));
                    break;
                case "Max":
                    Console.WriteLine(myList.Max());
                    break;
                case "Min":
                    Console.WriteLine(myList.Min());
                    break;
                case "Print":
                    Console.WriteLine(myList);
                    break;
            }
        }
    }
}