using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    public string model;
    public int engineSpeed;
    public int enginePower;
    public int cargoWeight;
    public string cargoType;
    public List<Tire> tire;


    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<Tire> tire)
    {
        this.model = model;
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
        this.tire = tire;
    }
}