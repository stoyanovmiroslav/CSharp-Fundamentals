using System;
using System.Collections.Generic;
using System.Text;


public class Topping
{
    private const double meat = 1.2;
    private const double veggies = 0.8;
    private const double cheese = 1.1;
    private const double sauce = 0.9;
    private List<string> toppings = new List<string> { "meat", "veggies", "cheese", "sauce" };


    private double weight;
    private string type;

    public Topping(double weight, string type)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double Calories
    {
        get
        {
            return CalculateCalories();
        }
    }

    public string Type
    {
        get { return type; }
        private set
        {
            if (toppings.Contains(value.ToLower()) == false)
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range[1..50].");
            }
            weight = value;
        }
    }

    private double CalculateCalories()
    {
        double grams = this.Weight * 2;

        switch (this.Type.ToLower())
        {
            case "meat": grams *= meat; break;
            case "veggies": grams *= veggies; break;
            case "cheese": grams *= cheese; break;
            case "sauce": grams *= sauce; break;

            default: throw new ArgumentException($"Cannot place {this.Type} on top of your pizza.");
        }
        return grams;
    }
}