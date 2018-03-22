using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    private string model;
    private double fuel;
    private double fuelConsumation;
    private double traveledDistance;

    public Car(string model, double fuel, double fuelConsumation)
    {
        this.model = model;
        this.fuel = fuel;
        this.fuelConsumation = fuelConsumation;
    }

    public double TraveledDistance
    {
        get { return traveledDistance; }
        set { traveledDistance = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumation; }
        set { fuelConsumation = value; }
    }

    public double Fuel
    {
        get { return fuel; }
        set { fuel = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}

