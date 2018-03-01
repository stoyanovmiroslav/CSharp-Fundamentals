using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        List<IIdentable> population = new List<IIdentable>();
        List<IBirthday> birthday = new List<IBirthday>(); 

        while ((input = Console.ReadLine()) != "End")
        {
            string[] splitInput = input.Split();

            switch (splitInput[0])
            {
                case "Citizen":
                    Citizen citizen = new Citizen(splitInput[1], int.Parse(splitInput[2]), splitInput[3], splitInput[4]);
                    population.Add(citizen);
                    birthday.Add(citizen);
                    break;
                case "Robot":
                    Robot robot = new Robot(splitInput[1], splitInput[2]);
                    population.Add(robot);
                    break;
                case "Pet":
                    Pet pet = new Pet(splitInput[1], splitInput[2]);
                    birthday.Add(pet);
                    break;
            }
        }
        string printBirthday = Console.ReadLine();
        birthday.Where(b => b.Birthday.EndsWith(printBirthday)).ToList().ForEach(b => Console.WriteLine(b.Birthday));
    }
}