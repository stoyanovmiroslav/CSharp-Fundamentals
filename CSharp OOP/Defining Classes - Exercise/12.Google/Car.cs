using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public string Speed { get; set; }

    public void AddCar(string model, string speed)
    {
        Model = model;
        Speed = speed;
    }

    public override string ToString()
    {
        return $"{Model} {Speed}";
    }
}

