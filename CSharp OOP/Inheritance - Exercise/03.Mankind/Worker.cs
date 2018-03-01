using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    private double SalaryPerHour()
    {
        double workHours = this.WorkHoursPerDay * 5.0;
        double salaryPerHour = (double)this.WeekSalary / workHours;
        return salaryPerHour;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"First Name: {this.FirstName}")
                      .AppendLine($"Last Name: {this.LastName}")
                      .AppendLine($"Week Salary: {this.WeekSalary:f2}")
                      .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
                      .AppendLine($"Salary per hour: {SalaryPerHour():f2}");

        return stringBuilder.ToString().TrimEnd();
    }
}