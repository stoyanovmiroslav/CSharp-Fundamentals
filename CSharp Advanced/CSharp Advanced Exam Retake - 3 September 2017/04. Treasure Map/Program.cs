using System;
using System.Text.RegularExpressions;

namespace _04._Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<![0-9])(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?![0-9])[^#!]*?(?(hash)!|#)";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var matches = Regex.Matches(input, pattern);

                string streetName = matches[matches.Count / 2].Groups["streetName"].ToString();
                string streetNumber = matches[matches.Count / 2].Groups["streetNumber"].ToString();
                string password = matches[matches.Count / 2].Groups["password"].ToString();

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}
