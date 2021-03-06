﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity)
    : base(name, airAffinity)
    {
    }
    
    public override string ToString()
    {
        return $"Air Monument: {this.Name}, Air Affinity: {this.Affinity}";
    }
}