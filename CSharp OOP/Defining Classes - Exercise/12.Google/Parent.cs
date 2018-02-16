using System;
using System.Collections.Generic;
using System.Text;


public class Parent
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public void AddParent(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{Name} {Birthday}";
    }
}
