using System;
using System.Collections.Generic;
using System.Text;

class Siamese
{
    public string Name { get; set; }
    public double EarSize { get; set; }

    public Siamese(string name, double earSize)
    {
        Name = name;
        EarSize = earSize;
    }

    public override string ToString()
    {
        return $"Siamese {Name} {EarSize}";
    }
}

