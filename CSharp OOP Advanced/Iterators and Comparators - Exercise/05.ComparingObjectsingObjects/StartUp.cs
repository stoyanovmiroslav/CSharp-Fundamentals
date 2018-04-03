using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        string input = string.Empty;
        List<Person> persons = new List<Person>();

        while ((input = Console.ReadLine()) != "END")
        {
            List<string> commandArgs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);
            string town = commandArgs[2];

            Person currentPersonperson = new Person(name, age, town);
            persons.Add(currentPersonperson);
        }

        int numberOfPerson = int.Parse(Console.ReadLine());
        Person person = persons[numberOfPerson - 1];
        persons.RemoveAt(numberOfPerson - 1);

        int numberOfNotEqualPersons = persons.Select(x => x.CompareTo(person)).Sum();
        int numberOfEqualPersons = persons.Count - numberOfNotEqualPersons;

        if (numberOfEqualPersons > 0)
        {
            Console.WriteLine($"{numberOfEqualPersons + 1} {numberOfNotEqualPersons} {persons.Count + 1}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}