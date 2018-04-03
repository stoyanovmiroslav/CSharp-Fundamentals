using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().Split(new string[] {"," , " "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        Lake<int> lake = new Lake<int>(input);

        Console.WriteLine(string.Join(", ", lake));
    }
}