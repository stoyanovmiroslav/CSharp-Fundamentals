
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string pizzaName = pizzaInput[1];
            Pizza pizza = new Pizza(pizzaName);

            Dough dough = CreateDough();
            pizza.SetDough(dough);

           
           //  dough.Calories;     

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] ingredients = input.Split(" ");

                Topping topping = new Topping(double.Parse(ingredients[2]), ingredients[1]);
                pizza.AddTopping(topping);

            }
            Console.WriteLine(pizza);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
    private static Dough CreateDough()
    {
        string[] doughInput = Console.ReadLine().Split();
        string flourType = doughInput[1];
        string bakingTechnique = doughInput[2];
        double doughWeight = double.Parse(doughInput[3]);
        Dough dough = new Dough(doughWeight, flourType, bakingTechnique);
        return dough;
    }
}

