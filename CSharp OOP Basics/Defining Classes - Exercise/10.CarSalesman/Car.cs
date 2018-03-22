using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private string engine;
    private string weight;
    private string color;

    public Car(string model, string engine, string weight, string color)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}

