using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
    private const string defaultCleansingStatus = "UNCLEANSED";
    private string name;
    private int age;
    private string cleansingStatus;

    protected Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.CleansingStatus = defaultCleansingStatus;
    }

    public string CleansingStatus
    {
        get { return cleansingStatus; }
        set { cleansingStatus = value; }
    }

    public int Age
    {
        get { return age; }
        protected set { age = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }
}