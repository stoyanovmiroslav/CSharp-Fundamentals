using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Salary
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
                Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                personList.Add(person);
            }
            decimal percentage = decimal.Parse(Console.ReadLine());
            
            personList.ForEach(x => x.IncreaseSalary(percentage));
            personList.ForEach(p => Console.WriteLine(p));
        }
    }
}
