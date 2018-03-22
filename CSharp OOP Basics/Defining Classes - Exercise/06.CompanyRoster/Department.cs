using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Department
{
    private string name;
    private List<Employee> employees;

    public decimal averageSalary => this.Employees.Select(e => e.Salary).Average();

    public Department()
    {
        employees = new List<Employee>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Employee> Employees
    {
        get { return employees; }
        private set { employees = value; }
    }

    public void AddEmployee(Employee employee)
    {
        this.Employees.Add(employee);
    }
}

