using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperNumber = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            if (upperNumber < 0) return;

            int[] numbers = new int[upperNumber];
            int currentNUmber = 1;
            Func<int, bool> possibleDivision = x => Divide(x, dividers);
            numbers.Select(n => n + currentNUmber++).Where(possibleDivision).ToList().ForEach(n => Console.Write($"{n} "));
        }

        private static bool Divide(int number, List<int> dividers)
        {
            bool isValid = true;

            for (int i = 0; i < dividers.Count; i++)
            {
                if (number % dividers[i] != 0)
                    isValid = false;
            }
            return isValid;
        }
    }
}
