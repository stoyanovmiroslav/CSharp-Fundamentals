using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = "";

        List<IIdentable> population = new List<IIdentable>();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] splitInput = input.Split();

                if (splitInput.Length == 3)
                {
                    Citizen citizen = new Citizen(splitInput[0], int.Parse(splitInput[1]), splitInput[2]);
                    population.Add(citizen);
                }
                else
                {
                    Robot robot = new Robot(splitInput[0], splitInput[1]);
                    population.Add(robot);
                }
        }
        string fakeIds = Console.ReadLine();
        population.Where(x => x.Id.EndsWith(fakeIds)).ToList().ForEach(x => Console.WriteLine(x.Id));
    }
}