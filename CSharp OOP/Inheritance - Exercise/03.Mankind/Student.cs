using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Any(c => char.IsLetterOrDigit(c) == false))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"First Name: {this.FirstName}")
                      .AppendLine($"Last Name: {this.LastName}")
                      .AppendLine($"Faculty number: {this.FacultyNumber}");

        return stringBuilder.ToString().TrimEnd();
    }
}