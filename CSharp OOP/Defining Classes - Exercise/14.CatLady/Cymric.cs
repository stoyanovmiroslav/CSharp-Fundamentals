using System;
using System.Collections.Generic;
using System.Text;

class Cymric
{
    public string Name { get; set; }
    public double FurLength { get; set; }

    public Cymric(string name, double furLength)
    {
        Name = name;
        FurLength = furLength;
    }

    public override string ToString()
    {
        return $"Cymric {Name} {FurLength:f2}"; 
    }
}
