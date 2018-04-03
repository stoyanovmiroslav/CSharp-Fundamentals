using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {

        int numberOfLines = int.Parse(Console.ReadLine());
        SortedSet<Person> personsSortedSet = new SortedSet<Person>();
        HashSet<Person> personsHashSet = new HashSet<Person>();

        for (int i = 0; i < numberOfLines; i++)
        {
            List<string> commandArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);

            Person currentPersonperson = new Person(name, age);

            personsSortedSet.Add(currentPersonperson);
            personsHashSet.Add(currentPersonperson);
        }

        Console.WriteLine(personsSortedSet.Count);
        Console.WriteLine(personsHashSet.Count);
    }
}