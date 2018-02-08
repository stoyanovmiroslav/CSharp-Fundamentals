using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\[[^\s\[\]]+<(\d+)REGEH(\d+)>[^\s\[\]]+]";

            List<int> numbers = new List<int>();
            foreach (Match m in Regex.Matches(input, pattern))
            {
                int firstIndex = int.Parse(m.Groups[1].ToString());
                int secondIndex = int.Parse(m.Groups[2].ToString());
                numbers.Add(firstIndex);
                numbers.Add(secondIndex);
            }

            for (int i = 1; i < numbers.Count; i++)
            {
                numbers[i] = numbers[i] + numbers[i - 1];
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                int index = numbers[i] % (input.Length - 1);
                string charather = input.Substring(index, 1);
                Console.Write("{0}", charather);
            }
        }
    }
}

