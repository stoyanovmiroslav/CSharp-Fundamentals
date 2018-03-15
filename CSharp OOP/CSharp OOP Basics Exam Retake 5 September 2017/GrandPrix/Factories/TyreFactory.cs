using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TyreFactory
{
    public static Tyre CreateTyre(List<string> commandArgs)
    {
        double tyreHardness = double.Parse(commandArgs[5]);
        string tyreType = commandArgs[4];

        if (tyreType == "Hard")
        {
            return new HardTyre(tyreHardness);
        }
        else if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(commandArgs[6]);
            return new UltrasoftTyre(tyreHardness, grip);
        }
        else
        {
            throw new ArgumentException();
        }
    }
}