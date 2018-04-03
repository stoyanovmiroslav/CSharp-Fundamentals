using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public int CompareTo(Person other)
    {
        int result = this.name.CompareTo(other.name);

        if (result == 0)
        {
            result = this.age.CompareTo(other.age);
        }

        return result;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is Person otherPerson)
        {
            return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}