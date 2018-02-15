using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Department> departments = new List<Department>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];
            string email = "n/a";
            int age = -1;

            if (input.Length == 5)
            {
                bool isNUmber = int.TryParse(input[4], out age);

                if (!isNUmber)
                {
                    email = input[4];
                    age = -1;
                }
            }
            else if (input.Length == 6)
            {
                email = input[4];
                age = int.Parse(input[5]);
            }

            Employee employee = new Employee(name, salary, position, email, age);

            if (!departments.Any(x => x.Name == department))
            {
                Department newDepartment = new Department();
                newDepartment.Name = department;
                departments.Add(newDepartment);
            }

            var currentDepartment = departments.FirstOrDefault(x => x.Name == department);
            currentDepartment.AddEmployee(employee);
        }
        var departmentHighestAverageSalary = departments.OrderByDescending(d => d.averageSalary).First();

        Console.WriteLine($"Highest Average Salary: {departmentHighestAverageSalary.Name}");
        foreach (var item in departmentHighestAverageSalary.Employees.OrderByDescending(s => s.Salary))
        {
            Console.WriteLine("{0} {1:f2} {2} {3}", item.Name, item.Salary, item.Email, item.Age);
        }
    }
}

