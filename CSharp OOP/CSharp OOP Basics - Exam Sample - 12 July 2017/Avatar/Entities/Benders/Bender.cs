using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Bender
{
    private int power;
    private string name;

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public abstract double GetPower();

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }
}