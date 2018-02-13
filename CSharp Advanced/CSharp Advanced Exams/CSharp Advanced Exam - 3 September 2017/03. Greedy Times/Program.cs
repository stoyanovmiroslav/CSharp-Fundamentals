using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var goldDict = new Dictionary<string, long>();
            var gemDict = new Dictionary<string, long>();
            var cashDict = new Dictionary<string, long>();

            long goldAmound = 0;
            long gemAmound = 0;
            long cashdAmound = 0;


            for (int i = 0; i < input.Length; i += 2)
            {
                string item = input[i];
                long itemValue = long.Parse(input[i + 1]);
                bool capacityIsValid = goldAmound + gemAmound + cashdAmound + itemValue <= capacity;

                if (!capacityIsValid)
                {
                    continue;
                }

                if (item.ToLower() == "gold")
                {
                    NewItemInTheBag(goldDict, item, itemValue);
                    goldAmound += itemValue;
                }
                else if (item.Length >= 4 && IsValid(itemValue, gemAmound, goldAmound))
                {
                    NewItemInTheBag(gemDict, item, itemValue);
                    gemAmound += itemValue;
                }
                else if (item.Length == 3 && IsValid(itemValue, cashdAmound, gemAmound))
                {
                    NewItemInTheBag(cashDict, item, itemValue);
                    cashdAmound += itemValue;
                }
            }


            if (goldDict.Any())
            {
                PrintDictionary(goldDict, "Gold");
                if (gemDict.Any())
                {
                    PrintDictionary(gemDict, "Gem");
                    if (cashDict.Any())
                    {
                        PrintDictionary(cashDict, "Cash");
                    }
                }

            }
        }

        private static void PrintDictionary(Dictionary<string, long> dict, string type)
        {
            Console.WriteLine($"<{type}> ${dict.Values.Sum()}");
            foreach (var item in dict.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }

        private static bool IsValid(long itemValue, long currentAmound, long maxAmound)
        {
            long sumIsValid = itemValue + currentAmound;
            return (sumIsValid <= maxAmound);
        }

        private static void NewItemInTheBag(Dictionary<string, long> dict, string item, long itemValue)
        {
            if (!dict.ContainsKey(item))
            {
                dict.Add(item, itemValue);
            }
            else
            {
                dict[item] += itemValue;
            }
        }
    }
}