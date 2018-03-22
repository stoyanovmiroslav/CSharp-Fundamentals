using System;
using System.Collections.Generic;
using System.Text;


class Engine
{
    public string model;
    public int power;
    public string displacement;
    public string efficiency;


    public Engine(string model, int power, string displacement, string efficiency)
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat($" {this.model}:\n"); //????
        sb.AppendFormat($"  Power: {this.power}\n");
        sb.AppendFormat($"  Displacement: {this.displacement}\n");
        sb.AppendFormat($"  Efficiency: {this.efficiency}\n");
        return sb.ToString();
    }
}
