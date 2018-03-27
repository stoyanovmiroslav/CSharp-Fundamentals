using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<string> listOfString = new List<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            listOfString.Add(input);
        }

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Swap<string> swap = new Swap<string>(listOfString);
        listOfString = swap.SwapElements(indexes);

        foreach (var currentString in listOfString)
        {
            Box<string> items = new Box<string>(currentString);
            Console.WriteLine(items);
        }
    }
}