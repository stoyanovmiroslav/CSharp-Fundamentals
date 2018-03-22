using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExtraRaceFactory
{
    public static Race CreateExtraRaceFactory(int id, string type, int length, string route, int prizePool, int extraParameter)
    {
        switch (type)
        {
            case "TimeLimit":
                return new TimeLimitRace(length, route, prizePool, extraParameter);
            case "Circuit":
                return new CircuitRace(length, route, prizePool, extraParameter);
            default:
                throw new ArgumentException();
        }
    }
}