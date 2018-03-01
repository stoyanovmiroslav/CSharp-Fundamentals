using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Citizen : IIdentable, IBirthday
{
    public Citizen(string name, int age, string id, string birthday)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthday;
    }
    public string Birthday { get; set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
}