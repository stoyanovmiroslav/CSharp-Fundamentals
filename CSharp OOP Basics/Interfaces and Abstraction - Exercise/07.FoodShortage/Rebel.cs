using System;
using System.Collections.Generic;
using System.Text;

public class Rebel : IBuyer
{
    private string name;
    private int age;
    private int food;
    private string group;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public void BuyFood()
    {
        this.Food += 5;
    }

    public string Group
    {
        get { return group; }
        set { group = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public int Food
    {
        get { return food; }
        set { food = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}