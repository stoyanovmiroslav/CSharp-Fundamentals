using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> personList = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], input[1], int.Parse(input[2]));
                personList.Add(person);
            }
            personList.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
