using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }


    public void AddCompany(string name, string department, double salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{Name} {Department} {Salary}";
    }

}

