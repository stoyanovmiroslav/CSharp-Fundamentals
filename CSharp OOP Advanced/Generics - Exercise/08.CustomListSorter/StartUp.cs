using System;
using System.Dynamic;

public class StartUp
{
    static void Main(string[] args)
    {
        string command = String.Empty;
        CustomList<string> customList = new CustomList<string>();

        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split();

            switch (commandArgs[0])
            {
                case "Add":
                    customList.Add(commandArgs[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(commandArgs[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(commandArgs[1]));
                    break;
                case "Swap":
                    customList.Swap(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(commandArgs[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    Console.WriteLine(customList);
                    break;
                case "Sort":
                    customList.Order();
                    break;
            }
        }
    }
}