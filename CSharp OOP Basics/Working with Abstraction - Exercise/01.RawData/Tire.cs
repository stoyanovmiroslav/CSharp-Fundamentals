﻿using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    private int age;
    private double pressure;

    public Tire(int age, double pressure)
    {
        this.age = age;
        this.pressure = pressure;
    }

    public double Pressure
    {
        get { return pressure; }
        set { pressure = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

}

