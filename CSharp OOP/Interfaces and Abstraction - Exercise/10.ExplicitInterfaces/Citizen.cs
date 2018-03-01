using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IResident, IPerson
{
    public Citizen(string name, int age, string country)
    {
        this.Name = name;
        this.Age = age;
        this.Country = country;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }

    void IPerson.GetName()
    {
        Console.WriteLine($"{this.Name}");
    }

    void IResident.GetName()
    {
        Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
    }
}