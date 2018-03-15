using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DriverFactory
{
    public static Driver CreateDriver(List<string> commandArgs, Car car)
    {
        string type = commandArgs[0];
        string name = commandArgs[1];

        if (type == "Endurance")
        {
            return new EnduranceDriver(name, car);
        }
        else if (type == "Aggressive")
        {
            return new AggressiveDriver(name, car); ;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}