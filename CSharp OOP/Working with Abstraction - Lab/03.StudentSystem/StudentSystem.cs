using System;
using System.Collections.Generic;
using System.Text;

public class StudentSystem
{
    private Dictionary<string, Student> students;

    public StudentSystem()
    {
        this.students = new Dictionary<string, Student>();
    }

    public void ParseCommand(string input)
    {
        string[] args = input.Split();
        string command = args[0];

        switch (command)
        {
            case "Create":
                CreateStudent(args);
                break;
            case "Show":
                ShowStudent(args);
                break;
        }
    }

    private void ShowStudent(string[] args)
    {
        var name = args[1];
        if (students.ContainsKey(name))
        {
            var student = students[name];
            string studentComment = "";

            if (student.Grade >= 5.00)
            {
                studentComment = "Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                studentComment = "Average student.";
            }
            else
            {
                studentComment = "Very nice person.";
            }
            Console.WriteLine($"{student.Name} is {student.Age} years old. {studentComment}");
        }
    }

    private void CreateStudent(string[] args)
    {
        var name = args[1];
        var age = int.Parse(args[2]);
        var grade = double.Parse(args[3]);

        if (!students.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            students[name] = student;
        }
    }
}