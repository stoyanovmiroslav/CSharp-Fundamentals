using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity)
    : base(name, waterAffinity)
    {
    }

    public override string ToString()
    {
        return $"Water Monument: {this.Name}, Water Affinity: {this.Affinity}";
    }
}
