using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<double> elements = new List<double>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());
            elements.Add(input);
        }

        double element = double.Parse(Console.ReadLine());

        Box<double> box = new Box<double>();
        int greaterElements = box.GreaterElements(elements, element);
        Console.WriteLine(greaterElements);
    }
}