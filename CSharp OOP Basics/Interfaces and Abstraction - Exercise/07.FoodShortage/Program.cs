using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        List<IBuyer> foods = new List<IBuyer>();

        ReadCitizenAndRebel(foods);

        while ((input = Console.ReadLine()) != "End")
        {
            string[] splitInput = input.Split();
            string name = splitInput[0];

            foods.Where(p => p.Name == name).ToList().ForEach(x => x.BuyFood());
        }
        Console.WriteLine(foods.Select(x => x.Food).Sum());
    }

    private static void ReadCitizenAndRebel(List<IBuyer> foods)
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] splitInput = Console.ReadLine().Split();

            if (splitInput.Length == 4)
            {
                Citizen citizen = new Citizen(splitInput[0], int.Parse(splitInput[1]), splitInput[2], splitInput[3]);
                foods.Add(citizen);
            }
            else if (splitInput.Length == 3)
            {
                Rebel rebel = new Rebel(splitInput[0], int.Parse(splitInput[1]), splitInput[2]);
                foods.Add(rebel);
            }
        }
    }
}