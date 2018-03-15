using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Monument
{
    private int affinity;
    private string name;

    protected Monument(string name, int affinity)
    {
        this.Name = name;
        this.Affinity = affinity;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int Affinity
    {
        get { return affinity; }
        set { affinity = value; }
    }
}