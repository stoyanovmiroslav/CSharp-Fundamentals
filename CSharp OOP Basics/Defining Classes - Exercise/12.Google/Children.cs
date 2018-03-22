using System;
using System.Collections.Generic;
using System.Text;


public class Children
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public void AddChildren(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{Name} {Birthday}";
    }
}

