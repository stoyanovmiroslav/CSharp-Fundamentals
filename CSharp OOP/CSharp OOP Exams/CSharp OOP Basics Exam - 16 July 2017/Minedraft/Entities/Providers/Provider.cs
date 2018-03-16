using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Provider : Minedraft
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) 
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10_000)
            {
                throw new ArgumentException("EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        string type = this.GetType().Name;
        int index = type.IndexOf("Provider");
        type = type.Insert(index, " ");

        return $"{type} - {this.Id}{Environment.NewLine}Energy Output: {this.EnergyOutput}";
    }
}