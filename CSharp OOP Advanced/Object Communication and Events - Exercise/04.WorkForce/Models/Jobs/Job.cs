using System;
using System.Collections.Generic;
using System.Text;
using _04.WorkForce.Contracts;

namespace _04.WorkForce
{
    public delegate void JobCompletedHandler(Job job);
    
    public class Job
    {
        public event JobCompletedHandler CompletedJob;

        private string name;
        private int hoursRequired;
        private IEmployee employee;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.name = name;
            this.hoursRequired = hoursRequired;
            this.employee = employee;
        }

        public void Update()
        {
            this.hoursRequired -= this.employee.HoursPerWeek;

            if (hoursRequired <= 0)
            {
                Console.WriteLine($"Job {this.name} done!");
                this.CompletedJob.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.hoursRequired}";
        }
    }
}
