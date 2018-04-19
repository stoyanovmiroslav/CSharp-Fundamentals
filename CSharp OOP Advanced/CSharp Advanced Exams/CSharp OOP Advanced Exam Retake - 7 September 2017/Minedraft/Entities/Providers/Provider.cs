using System;

public abstract class Provider : IProvider
{
    private const double DurabilityStart = 1000;
    private int id;
    private double energyOutput;
    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = DurabilityStart;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        set { energyOutput = value; }
    }

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public double Durability
    {
        get { return durability; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Durability should be positive number!");
            }
            durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= 100;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}