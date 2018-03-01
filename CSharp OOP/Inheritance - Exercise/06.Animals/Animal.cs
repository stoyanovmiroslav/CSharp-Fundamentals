using System;
using System.Collections.Generic;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return name; }
        set
        {
            IsNullOrWhiteSpace(value);
            name = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            IsNullOrWhiteSpace(value);
            if (value != "Male" && value != "Female")
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    private static void IsNullOrWhiteSpace(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Invalid input!");
        }
    }

    public virtual string ProduceSound()
    {
        return "Woow";
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{this.GetType()}")
                     .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                     .AppendLine($"{this.ProduceSound()}");

        return stringBuilder.ToString().TrimEnd();
    }
}