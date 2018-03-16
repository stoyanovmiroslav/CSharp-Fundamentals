using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Harvester : Minedraft
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) 
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20_000)
            {
                throw new ArgumentException("EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("OreOutput");
            }
            oreOutput = value;
        }
    }

    public override string ToString()
    {
        string type = this.GetType().Name;
        int index = type.IndexOf("Harvester");
        type = type.Insert(index, " ");

        return $"{type} - {this.Id}{Environment.NewLine}Ore Output: {this.OreOutput}{Environment.NewLine}Energy Requirement: {this.EnergyRequirement}";
    }
}