using System;
using System.Collections.Generic;
using System.Text;


class StreetExtraordinaire
{
    public string Name { get; set; }
    public double DecibelsOfMeows { get; set; }

    public StreetExtraordinaire(string name, double decibelsOfMeows)
    {
        Name = name;
        DecibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {Name} {DecibelsOfMeows}";
    }
}
