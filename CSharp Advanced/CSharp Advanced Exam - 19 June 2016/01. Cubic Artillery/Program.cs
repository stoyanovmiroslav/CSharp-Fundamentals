using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            int bunkersCapacity = int.Parse(Console.ReadLine());
            string input = "";

            var dict = new Dictionary<string, Queue<int>>();
            List<string> bunkers = new List<string>();

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                string[] splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < splitInput.Length; i++)
                {
                    if (IsNumerics(splitInput[i]))
                    {
                        int weapon = int.Parse(splitInput[i]);
                        StoreWeapons(bunkers, dict, weapon, bunkersCapacity);
                    }
                    else
                    {
                        string bunker = splitInput[i];
                        bunkers.Add(bunker);
                        dict.Add(bunker, new Queue<int>());
                    }

                    if (bunkers.Count > 1)
                    {
                        bool bunkerIsFull = IsBunkerFull(bunkers, dict, bunkersCapacity);
                        if (bunkerIsFull)
                        {
                            Console.WriteLine($"{bunkers[0]} -> {string.Join(", ", dict[bunkers[0]])}");
                            dict.Remove(bunkers[0]);
                            bunkers.RemoveAt(0);
                        }
                    }
                }
            }
        }

        private static bool IsBunkerFull(List<string> bunkers, Dictionary<string, Queue<int>> dict, int bunkersCapacity)
        {
            if (dict[bunkers[0]].Sum() == bunkersCapacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void StoreWeapons(List<string> bunkers, Dictionary<string, Queue<int>> dict, int weapon, int bunkersCapacity)
        {
            if (bunkers.Count > 0 && bunkersCapacity >= weapon)
            {
                for (int i = 0; i < bunkers.Count; i++)
                {
                    string bunkerName = bunkers[i];

                    if (IsWeaponsCanFit(dict, weapon, bunkerName, bunkersCapacity))
                    {
                        dict[bunkerName].Enqueue(weapon);
                        break;
                    }
                    else if (bunkers.Count > 1)
                    {
                        Console.WriteLine($"{bunkers[0]} -> {string.Join(", ", dict[bunkers[0]])}");
                        dict.Remove(bunkers[0]);
                        bunkers.RemoveAt(0);
                        i--;
                    }
                    else if (bunkers.Count == 1)
                    {
                        OrderLastBunker(bunkers, dict, weapon, bunkersCapacity);
                    }
                }
            }
            else if (bunkers.Count > 1)
            {
                if (dict[bunkers[0]].Sum() > 0)
                {
                    Console.WriteLine($"{bunkers[0]} -> {string.Join(", ", dict[bunkers[0]])}");
                }
                else
                {
                    Console.WriteLine($"{bunkers[0]} -> Empty");
                }
                dict.Remove(bunkers[0]);
                bunkers.RemoveAt(0);
            }
        }

        private static bool IsWeaponsCanFit(Dictionary<string, Queue<int>> dict, int weapon, string bunkerName, int bunkersCapacity)
        {
            int currentSumWeapons = dict[bunkerName].Sum();
            int capacity = weapon + currentSumWeapons;
            return capacity <= bunkersCapacity;
        }

        private static void OrderLastBunker(List<string> bunkers, Dictionary<string, Queue<int>> dict, int weapon, int bunkersCapacity)
        {
            int n = dict[bunkers[0]].Count;
            for (int i = 0; i < n; i++)
            {
                dict[bunkers[0]].Dequeue();
                if (IsWeaponsCanFit(dict, weapon, bunkers[0], bunkersCapacity))
                {
                    dict[bunkers[0]].Enqueue(weapon);
                    break;
                }
            }

        }

        private static bool IsNumerics(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
