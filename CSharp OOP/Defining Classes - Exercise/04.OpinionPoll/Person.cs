using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    string name;
    int age;

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Person(string name, int age)
    {
        this.age = age;
        this.name = name;
    }

    public Person(int age)
    {
        this.age = age;
        this.name = "No name";
    }

    public Person()
    {
        this.age = 1;
        this.name = "No name";
    }
}

