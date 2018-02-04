using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input = null;
            List<string> commandsRecords = new List<string>();

            while ((input = Console.ReadLine()) != "Forge")
            {
                ExcludeAndReverse(input, commandsRecords);
            }

            List<int> filtered = new List<int>();
            GetFiltered(gems, filtered, commandsRecords);
            gems = gems.Where(n => !filtered.Contains(n)).ToList();

            Console.WriteLine(String.Join(" ", gems));
        }

        private static void ExcludeAndReverse(string input, List<string> commandsRecords)
        {
            string[] splitInput = input.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string command = splitInput[0];
            string type = splitInput[1];
            int parameter = int.Parse(splitInput[2]);

            string typeAndParameter = $"{type} | {parameter}";

            if (command == "Exclude")
            {
                commandsRecords.Add(typeAndParameter);
            }
            if (command == "Reverse")
            {
                commandsRecords.Remove(typeAndParameter);
            }
        }

        private static Func<List<int>, List<int>> Func(string command, int parameter)
        {
            switch (command)
            {
                case "Sum Left":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        return gem + leftGem == parameter;
                    }).ToList();

                case "Sum Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return gem + rightGem == parameter;
                    }).ToList();

                case "Sum Left Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return gem + rightGem + leftGem == parameter;
                    }).ToList();

                default:
                    throw new ArgumentException();
            }
        }

        private static void GetFiltered(List<int> gems, List<int> filtered, List<string> commandsRecords)
        {
            for (int i = 0; i < commandsRecords.Count; i++)
            {
                string[] excludeCommand = commandsRecords[i].Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                string command = excludeCommand[0];
                int parameter = int.Parse(excludeCommand[1]);
                Func<List<int>, List<int>> func = Func(command, parameter);
                filtered.AddRange(func(gems));
            }
        }
    }
}
