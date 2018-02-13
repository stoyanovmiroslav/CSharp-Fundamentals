using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, string>>();

            string input = "";

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] splitInput = input.Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
                string name = splitInput[0];

                for (int i = 1; i < splitInput.Length; i++)
                {
                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, new Dictionary<string, string>());
                    }

                    string[] keyValue = splitInput[i].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    string key = keyValue[0];
                    string value = keyValue[1];
                    if (!dict[name].ContainsKey(key))
                    {
                        dict[name].Add(key, value);
                    }
                    else
                    {
                        dict[name][key] = value;
                    }
                }
            }

            string[] killNameInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string killName = killNameInput[1]; // ako iam dve imena ?

            int indexSum = 0;
            Console.WriteLine($"Info on {killName}:");
            foreach (var item in dict[killName].OrderBy(x => x.Key))
            {
                Console.WriteLine("---{0}: {1}", item.Key, item.Value);
                int sumKeyLenght = item.Key.Length;
                int sumValueLenght = item.Value.Length;
                indexSum += sumKeyLenght + sumValueLenght;
            }

            int diff = targetIndex - indexSum;
            Console.WriteLine($"Info index: {indexSum}");
            if (diff <= 0)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {diff} more info.");
            }
        }
    }
}
