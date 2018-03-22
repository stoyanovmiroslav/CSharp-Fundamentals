﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity)
    : base(name, fireAffinity)
    {

    }

    public override string ToString()
    {
        return $"Fire Monument: {this.Name}, Fire Affinity: {this.Affinity}";
    }
}