using System;
using System.Collections.Generic;
using System.Text;

public class AggressiveDriver : Driver
{
    private const double fuelConsumption = 2.7;
    private const double speedMultiplierAggresiveDriver = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, fuelConsumption)
    {
    }

    public override double Speed => base.Speed * speedMultiplierAggresiveDriver;
}
