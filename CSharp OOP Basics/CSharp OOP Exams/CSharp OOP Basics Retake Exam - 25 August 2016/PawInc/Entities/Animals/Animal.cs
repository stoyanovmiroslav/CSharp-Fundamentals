using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
    private string name;
    private int age;
    private bool cleansingStatus;

    protected Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.CleansingStatus = false;
    }

    public bool CleansingStatus
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