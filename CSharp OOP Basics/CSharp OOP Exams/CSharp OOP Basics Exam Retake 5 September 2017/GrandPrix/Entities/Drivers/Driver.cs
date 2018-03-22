using System;
using System.Collections.Generic;
using System.Text;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private string status;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.Status = "racing";
    }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void ChangeDriverStatus(string newStatus)
    {
        this.Status = newStatus;
    }

    public string Status
    {
        get { return status; }
        protected set { status = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        set { fuelConsumptionPerKm = value; }
    }

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}