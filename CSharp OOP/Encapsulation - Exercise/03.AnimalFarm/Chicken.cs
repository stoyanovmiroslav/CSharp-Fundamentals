﻿using System;
using System.Collections.Generic;
using System.Text;

public class Chicken
{
    private const int MIN_AGE = 0;
    private const int MAX_AGE = 15;

    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        this.Age = age;
        this.Name = name;
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value < MIN_AGE || value > MAX_AGE)
            {
                throw new ArgumentException("Age should be between 0 and 15.");
            }
            this.age = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            this.name = value;
        }
    }

    public double ProductPerDay
    {
        get { return CalculateProductPerDay(); }
    }

    private double CalculateProductPerDay()
    {
        switch (this.Age)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return 1.5;
            case 4:
            case 5:
            case 6:
            case 7:
                return 2;
            case 8:
            case 9:
            case 10:
            case 11:
                return 1;
            default:
                return 0.75;
        }
    }
}