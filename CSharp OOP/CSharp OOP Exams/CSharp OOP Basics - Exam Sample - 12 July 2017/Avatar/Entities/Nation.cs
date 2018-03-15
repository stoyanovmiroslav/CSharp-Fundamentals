using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }
 
    public void AddBender(Bender bender)
    {
        benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        monuments.Add(monument);
    }

    public double CalculatePower()
    {
        double totalPowerBender = benders.Select(n => n.GetPower()).Sum();
        double totalPowerMonument = monuments.Select(n => n.Affinity).Sum();

        double totalPower = totalPowerBender + ((totalPowerBender / 100) * totalPowerMonument);
        return totalPower;
    }

    public void ClearArmy()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append("Benders:");
        if (this.benders.Count != 0)
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.benders.Select(b => $"###{b}")));
        }
        else
        {
            result.AppendLine(" None");
        }

        result.Append("Monuments:");
        if (this.monuments.Count != 0)
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.monuments.Select(m => $"###{m}")));
        }
        else
        {
            result.Append(" None");
        }

        return result.ToString();
    }
}