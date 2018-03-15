using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity)
    : base(name, earthAffinity)
    {
    }

    public override string ToString()
    {
        return $"Earth Monument: {this.Name}, Earth Affinity: {this.Affinity}";
    }
}