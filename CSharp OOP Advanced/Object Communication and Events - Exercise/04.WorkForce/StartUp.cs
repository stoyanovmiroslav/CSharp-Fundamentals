using System;
using System.Collections.Generic;
using System.Linq;
using _04.WorkForce.Contracts;

namespace _04.WorkForce
{
    class StartUp
    {
        static void Main(string[] args)
        {
            JobList jobs = new JobList();
            List<IEmployee> employees = new List<IEmployee>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "Job":
                        IEmployee employee = employees.First(e => e.Name == commandArgs[3]);
                        jobs.AddJob(new Job(commandArgs[1], int.Parse(commandArgs[2]), employee));
                        break;
                    case "StandardEmployee":
                        employees.Add(new StandardEmployee(commandArgs[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(commandArgs[1]));
                        break;
                    case "Pass":
                        jobs.ToList().ForEach(j => j.Update());
                        break;
                    case "Status":
                        jobs.ForEach(Console.WriteLine);
                        break;
                }
            }
        }
    }
}
