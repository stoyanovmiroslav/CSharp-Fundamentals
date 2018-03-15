using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.addOns = new List<string>();
        this.Horsepower += (this.Horsepower * 50 / 100);
        this.Suspension -= (this.Suspension * 25 / 100);
    }

    public void AddOnsService(string addOns)
    {
        this.AddOns.Add(addOns);
    }

    private List<string> AddOns
    {
        get { return addOns; }
        set { addOns = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Add-ons: ");

        if (addOns != null && addOns.Count > 0)
        {
            sb.AppendLine(string.Join(", ", addOns));
        }
        else
        {
            sb.AppendLine("None");
        }

        return base.ToString() + sb.ToString().Trim();
    }
}