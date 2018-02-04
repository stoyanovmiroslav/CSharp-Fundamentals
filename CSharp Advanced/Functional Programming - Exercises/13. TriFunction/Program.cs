using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> func = IsEqualOrLarger;
            string name = FirstName(names, number, func);
            Console.WriteLine(name);
        }

        private static string FirstName(List<string> names, int number, Func<string, int, bool> func)
        {
            string name = "";
            for (int i = 0; i < names.Count; i++)
            {
                if (func(names[i], number))
                {
                    name = names[i];
                    break;
                }
            }
            return name;
        }

        private static bool IsEqualOrLarger(string name, int number)
        {
            int charsSum = 0;
            for (int i = 0; i < name.Length; i++)
            {
                charsSum += (int)name[i];
            }

            return charsSum >= number;
        }
    }
}