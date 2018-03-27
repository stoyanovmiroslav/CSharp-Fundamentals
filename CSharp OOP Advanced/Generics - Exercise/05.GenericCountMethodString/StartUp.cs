using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<string> elements = new List<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            elements.Add(input);
        }

        string element = Console.ReadLine();

        Box<string> box = new Box<string>();
        int greaterElements = box.GreaterElements(elements, element);
        Console.WriteLine(greaterElements);
    }
}