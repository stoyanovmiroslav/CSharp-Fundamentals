using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        long capacityOfBag = long.Parse(Console.ReadLine());
        string[] sequenceOfItem = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();
        long gold = 0;
        long gem = 0;
        long cash = 0;

        for (int i = 0; i < sequenceOfItem.Length; i += 2)
        {
            string type = sequenceOfItem[i];
            long amountValue = long.Parse(sequenceOfItem[i + 1]);

            long sumItems = gold + gem + cash;

            if (capacityOfBag < sumItems + amountValue)
            {
                continue;
            }

            string item = string.Empty;

            if (type.Length == 3)
            {
                item = "Cash";
                if (cash + amountValue > gem) continue;
                cash += amountValue;
            }
            else if (type.ToLower().EndsWith("gem") && type.Length >= 4)
            {
                item = "Gem";
                if (gem + amountValue > gold) continue;
                gem += amountValue;
            }
            else if (type.ToLower() == "gold")
            {
                item = "Gold";
                gold += amountValue;
            }
            else
            {
                continue;
            }
            CreateItem(bag, type, amountValue, item);
        }

        foreach (var type in bag)
        {
            Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");

            foreach (var item in type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }
    }

    private static void CreateItem(Dictionary<string, Dictionary<string, long>> bag, string name, long count, string item)
    {
        if (!bag.ContainsKey(item))
        {
            bag.Add(item, new Dictionary<string, long>());
        }
        if (!bag[item].ContainsKey(name))
        {
            bag[item].Add(name, count);
        }
        else
        {
            bag[item][name] += count;
        }
    }
}
