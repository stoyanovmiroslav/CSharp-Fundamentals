using System;
using System.Collections.Generic;
using System.Text;


public class Dough
{
    private const double white = 1.5;
    private const double wholegrain = 1.0;
    private const double crispy = 0.9;
    private const double chewy = 1.1;
    private const double homemade = 1.0;

    private double weight;
    private string flourType;
    private string bakingTechnique;

    public Dough(double weight, string flourType, string bakingTechnique)
    {
        this.Weight = weight;
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
    }

    public string BakingTechnique        // probably need check
    {
        get { return bakingTechnique; }
        set { bakingTechnique = value; }
    }

    public string FlourType   // probably need check
    {
        get { return flourType; }
        set { flourType = value; }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public double Calories
    {
        get
        {
            return CalculateCalories();
        }
    }

    private double CalculateCalories()
    {
        double grams = this.Weight * 2;

        switch (this.flourType.ToLower())
        {
            case "wholegrain": grams *= wholegrain; break;
            case "white": grams *= white; break;
            default: throw new ArgumentException("Invalid type of dough."); 
        }

        switch (this.bakingTechnique.ToLower())
        {
            case "crispy": grams *= crispy; break;
            case "chewy": grams *= chewy; break;
            case "homemade": grams *= homemade; break;
            default: throw new ArgumentException("Invalid type of dough.");
        }
        return grams;
    }
}