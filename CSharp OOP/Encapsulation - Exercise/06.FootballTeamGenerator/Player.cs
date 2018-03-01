using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Player
{
    private string name;
    private double stats;

    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;


    public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
        this.stats = CalculateStats();
    }

    private double CalculateStats()
    {
        double stats = this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting;
        return Math.Round(stats / 5);
    }

    private void StatsValidation(double value, string type)
    {
        if (value < 1 || value > 100)
        {
            throw new ArgumentException($"{type} should be between 0 and 100.");
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public double Stars
    {
        get { return stats; }
    }

    private double Shooting
    {
        get { return shooting; }
        set
        {
            StatsValidation(value, "Shooting");
            shooting = value;
        }
    }

    private double Passing
    {
        get { return passing; }
        set
        {
            StatsValidation(value, "Passing");
            passing = value;
        }
    }

    private double Dribble
    {
        get { return dribble; }
        set
        {
            StatsValidation(value, "Dribble");
            dribble = value;
        }
    }

    private double Sprint
    {
        get { return sprint; }
        set
        {
            StatsValidation(value, "Sprint");
            sprint = value;
        }
    }

    private double Endurance
    {
        get { return endurance; }
        set
        {
            StatsValidation(value, "Endurance");
            endurance = value;
        }
    }
}