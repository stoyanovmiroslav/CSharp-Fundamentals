using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Minedraft
{
    private string id;

    protected Minedraft(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }
}