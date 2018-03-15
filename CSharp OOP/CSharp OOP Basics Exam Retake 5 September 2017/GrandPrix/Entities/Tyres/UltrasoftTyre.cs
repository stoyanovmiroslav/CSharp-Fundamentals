using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }

    public override double ReduceDegradation()
    {
       return this.Degradation = this.Degradation - (this.Hardness + this.Grip);
    }

    public double Grip
    {
        get { return grip; }
        set { grip = value; }
    }

    public override string Name => "Ultrasoft";
}