using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(string typeOfVehicle, double FuelQuantity, double fuelConsumption)
            : base(typeOfVehicle, FuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + 1.6;
        }

        public override void Refuel(double liters)
        {
            double lostLiters = liters * 5 / 100.0;
            this.FuelQuantity += liters - lostLiters;
        }
    }
}
