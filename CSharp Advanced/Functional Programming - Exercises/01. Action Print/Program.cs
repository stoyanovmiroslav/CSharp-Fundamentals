using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = name => Console.WriteLine(name);
            print(String.Join("\n", input));
        }
    }
}
