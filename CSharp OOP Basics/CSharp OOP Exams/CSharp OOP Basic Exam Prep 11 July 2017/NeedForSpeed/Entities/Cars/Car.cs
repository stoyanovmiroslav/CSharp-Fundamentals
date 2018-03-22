using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public int TimePerformance(Race race)
    {
        return race.Lenght * ((this.Horsepower / 100) * this.Acceleration);
    }

    public int OverallPerformance()
    {
        return (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public int EnginePerformance()
    {
        return this.Horsepower / this.Acceleration;
    }

    public int SuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }

    public void TuneUpgrade(int tuneIndex)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += (tuneIndex / 2);
    }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public int Horsepower
    {
        get { return horsepower; }
        set { horsepower = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        set { yearOfProduction = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString();
    }
}