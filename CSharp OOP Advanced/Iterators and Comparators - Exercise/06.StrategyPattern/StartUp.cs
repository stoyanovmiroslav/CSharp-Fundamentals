using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {

        int numberOfLines = int.Parse(Console.ReadLine());
        string input = string.Empty;
        SortedSet<Person> personsSortedByAge = new SortedSet<Person>(new PersonAgeComparer());
        SortedSet<Person> personsSortedByName = new SortedSet<Person>(new PersonNameComparer());

        for (int i = 0; i < numberOfLines; i++)
        {
            List<string> commandArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);

            Person currentPersonperson = new Person(name, age);

            personsSortedByAge.Add(currentPersonperson);
            personsSortedByName.Add(currentPersonperson);
        }

        Console.WriteLine(string.Join(Environment.NewLine, personsSortedByName));
        Console.WriteLine(string.Join(Environment.NewLine, personsSortedByAge));
    }
}