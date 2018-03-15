using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(string typeOfVehicle, double fuelQuantity, double fuelConsumption)
            : base(typeOfVehicle, fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }
    }
}