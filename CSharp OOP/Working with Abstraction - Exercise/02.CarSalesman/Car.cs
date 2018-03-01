using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    public string model;
    public Engine engine;
    public string weight;
    public string color;

    public Car(string model, Engine engine, string weight, string color)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat($"{this.model}:\n");
        sb.Append($"{this.engine}");
        sb.AppendFormat($" Weight: {this.weight}\n");
        sb.AppendFormat($" Color: {this.color}");
        return sb.ToString();
    }
}