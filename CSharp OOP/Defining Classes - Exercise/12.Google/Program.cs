using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string input = "";
        List<Person> persons = new List<Person>();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] splitInfo = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string name = splitInfo[0];

            if (!persons.Any(x => x.Name == name))
            {
                Person person = new Person();
                person.Name = name;
                persons.Add(person);
            }

            var currentPerson = persons.First(x => x.Name == name);

            switch (splitInfo[1])
            {
                case "company":
                    Company company = new Company();
                    company.AddCompany(splitInfo[2], splitInfo[3], double.Parse(splitInfo[4]));
                    currentPerson.Company = company;
                    break;
                case "pokemon":
                    Pokemon pokemon = new Pokemon();
                    pokemon.AddPokemon(splitInfo[2], splitInfo[3]);
                    currentPerson.Pokemons.Add(pokemon);
                    break;
                case "parents":
                    Parent parent = new Parent();
                    parent.AddParent(splitInfo[2], splitInfo[3]);
                    currentPerson.Parents.Add(parent);
                    break;
                case "children":
                    Children children = new Children();
                    children.AddChildren(splitInfo[2], splitInfo[3]);
                    currentPerson.Childrens.Add(children);
                    break;
                case "car":
                    Car car = new Car();
                    car.AddCar(splitInfo[2], splitInfo[3]);
                    currentPerson.Car = car;
                    break;
            }
        }

        string personNeededInfo = Console.ReadLine();
        var personInfo = persons.First(x => x.Name == personNeededInfo);

        PrinOutput(personInfo);
    }

    private static void PrinOutput(Person personInfo)
    {
        Console.WriteLine(personInfo.Name);
        Console.WriteLine("Company:");
        if (personInfo.Company != null)
        {
            Console.WriteLine($"{personInfo.Company.Name} {personInfo.Company.Department} {personInfo.Company.Salary:f2}");
        }

        Console.WriteLine("Car:");
        if (personInfo.Car != null)
        {
            Console.WriteLine(personInfo.Car);
        }

        Console.WriteLine("Pokemon:");
        personInfo.Pokemons.ForEach(p => Console.WriteLine(p));

        Console.WriteLine("Parents:");
        personInfo.Parents.ForEach(p => Console.WriteLine(p));

        Console.WriteLine("Children:");
        personInfo.Childrens.ForEach(p => Console.WriteLine(p));
    }
}