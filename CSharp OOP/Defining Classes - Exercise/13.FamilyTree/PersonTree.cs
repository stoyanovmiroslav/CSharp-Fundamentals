using System;
using System.Collections.Generic;
using System.Text;


public class PersonTree
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public PersonTree(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

}