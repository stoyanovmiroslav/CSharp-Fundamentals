using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _01.GenericBoxOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> listOfString = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                listOfString.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap<int> swap = new Swap<int>(listOfString);
            listOfString = swap.SwapMetod(indexes);

            foreach (var item in listOfString)
            {
                Box<int> items = new Box<int>(item);
                Console.WriteLine(items);
            }
        }
    }
}