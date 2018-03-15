using System;
using System.Collections.Generic;
using System.Text;

public class EnduranceDriver : Driver
{
    private const double FUEL_CONSUMPTION = 1.5;

    public EnduranceDriver(string name, Car car) 
        : base(name, car, FUEL_CONSUMPTION)
    {
    }
}