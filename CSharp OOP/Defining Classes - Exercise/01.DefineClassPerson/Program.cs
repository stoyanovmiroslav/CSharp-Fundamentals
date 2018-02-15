using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Problem 1. Define a Class Person; Problem 2.Creating Constructors; Problem 3.Oldest Family Member;

        int members = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < members; i++)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person();
            person.Name = name;
            person.Age = age;
            family.AddMember(person);
        }
        var oldestPerson = family.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}

