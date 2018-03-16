using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ProviderFactory
{
    public static Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        switch (type)
        {
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            case "Solar":
                return new SolarProvider(id, energyOutput);
            default:
                throw new ArgumentException();
        }
    }
}