using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string evenOdd = Console.ReadLine();  

            int startIndex = input[0];
            int endIndex = input[1];
                
            Predicate<int> evenOrOdd = x => x % 2 == 0;

            for (int number = startIndex; number <= endIndex; number++)
            {
                if (evenOrOdd(number) && evenOdd == "even")
                {
                    Console.Write($"{number} ");
                }
                else if(!evenOrOdd(number) && evenOdd == "odd")
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}