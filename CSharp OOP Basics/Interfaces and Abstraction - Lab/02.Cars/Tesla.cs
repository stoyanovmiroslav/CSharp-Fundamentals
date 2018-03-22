using System;
using System.Collections.Generic;
using System.Text;

public class Tesla : ICar, IElectricCar
{
    public int Batery { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }

    public Tesla(string model, string color, int batery)
    {
        this.Model = model;
        this.Color = color;
        this.Batery = batery;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!"; 
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Batery} Batteries")
                     .AppendLine(Start())
                     .AppendLine(Stop());

        return stringBuilder.ToString().TrimEnd();
    }
}