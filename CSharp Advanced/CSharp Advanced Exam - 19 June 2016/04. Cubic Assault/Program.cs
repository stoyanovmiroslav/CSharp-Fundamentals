using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cubic_Assault
{
    class Program
    {
        static void Main(string[] args)
        {                                    
            string input = "";
            var dict = new Dictionary<string, Dictionary<string, long>>();
            while ((input = Console.ReadLine()) != "Count em all")
            {
                string[] splitInput = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string regionName = splitInput[0];
                string type = splitInput[1];
                long typeCount = long.Parse(splitInput[2]);
                //1 000 000 

                if (!dict.ContainsKey(regionName))
                {
                    dict.Add(regionName, new Dictionary<string, long>());
                    dict[regionName].Add(type, typeCount);

                    CreateAllTypes(dict, regionName, type);
                    CheckValue(dict, regionName, type);
                }

                else
                {
                    dict[regionName][type] += typeCount;
                    CheckValue(dict, regionName, type);
                }


            }

            foreach (var regions in dict.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0}", regions.Key);

                foreach (var types in regions.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine("-> {0} : {1}", types.Key, types.Value);
                }
            }

        }

        private static void CreateAllTypes(Dictionary<string, Dictionary<string, long>> dict, string regionName, string type)
        {
            if (!dict[regionName].ContainsKey("Green"))
            {
                dict[regionName].Add("Green", 0);
            }
            if (!dict[regionName].ContainsKey("Black"))
            {
                dict[regionName].Add("Black", 0);
            }
            if (!dict[regionName].ContainsKey("Red"))
            {
                dict[regionName].Add("Red", 0);
            }
        }

        private static void CheckValue(Dictionary<string, Dictionary<string, long>> dict, string regionName, string type)
        {
            long amount = dict[regionName][type];

            if (type == "Green" && amount >= 1000000)
            {
                ChangeAmout(dict, amount, regionName, "Red", "Green");
                CheckValue(dict, regionName, "Red");
            }
            else if (type == "Red" && amount >= 1000000)
            {
                ChangeAmout(dict, amount, regionName, "Black", "Red");
            }
        }

        private static void ChangeAmout(Dictionary<string, Dictionary<string, long>> dict, long amount, string regionName, string currentType, string type)
        {
            long currentAmount = amount % 1000000;
            long nextAmount = amount / 1000000;
            dict[regionName][type] = currentAmount;
            dict[regionName][currentType] += nextAmount;
        }
    }
}
