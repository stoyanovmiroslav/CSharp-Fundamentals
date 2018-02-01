using System;
using System.Collections.Generic;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] nameAndAge = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string name = nameAndAge[0];
                int ageInput = int.Parse(nameAndAge[1]);
                dict.Add(name, ageInput);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            foreach (var item in dict)
            {
                if (tester(item.Value))
                {
                    printer(item);
                }
            }

        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name": return person => Console.WriteLine("{0}", person.Key);
                case "age": return person => Console.WriteLine("{0}", person.Value);
                case "name age": return person => Console.WriteLine("{0} - {1}", person.Key, person.Value);
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }
    }
}
