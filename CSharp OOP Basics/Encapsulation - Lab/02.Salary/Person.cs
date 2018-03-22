using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public void IncreaseSalary(decimal percetage)
    {
        if (this.age < 30)
        {
            percetage = percetage / 2;
        }

        salary = salary + (salary * percetage / 100);
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public int Age
    {
        get { return age; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public string FirstName
    {
        get { return firstName; }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.";
    }
}