using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    // model, engine, cargo and a collection of exactly 4 tires.
    private string name;
    private int engineSpeed;
    private int enginePower;
    private int cargoWeight;
    private string cargoType;
    private List<double> tiresPressure;
    private List<int> tiresAge;


    public Car(string name, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<double> tiresPressure, List<int> tiresAge)
    {
        this.name = name;
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
        this.cargoWeight = cargoWeight;
        this.CargoType = cargoType;
        this.tiresPressure = tiresPressure;
        this.tiresAge = tiresAge;
    }

    public static object Select { get; internal set; }

    public List<int> TiresAge
    {
        get { return tiresAge; }
        set { tiresAge = value; }
    }

    public string CargoType
    {
        get { return cargoType; }
        set { cargoType = value; }
    }

    public int EnginePower
    {
        get { return enginePower; }
        set { enginePower = value; }
    }

    public List<double> TiresPressure
    {
        get { return tiresPressure; }
        set { tiresPressure = value; }
    }

    public int CargoWeight
    {
        get { return cargoWeight; }
        set { cargoWeight = value; }
    }

    public int Engine
    {
        get { return engineSpeed; }
        set { engineSpeed = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

