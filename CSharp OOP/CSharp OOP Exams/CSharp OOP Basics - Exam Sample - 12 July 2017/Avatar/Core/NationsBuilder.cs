using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NationsBuilder
{
    Dictionary<string, Nation> nations;
    private List<string> pastWars;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation() },
            {"Fire", new Nation() },
            {"Earth", new Nation() },
            {"Water", new Nation() }
        };

        this.pastWars = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];

        if (nations.ContainsKey(type))
        {
            Bender bender = BenderFactory.CreateBender(benderArgs);
            nations[type].AddBender(bender);
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];

        if (nations.ContainsKey(type))
        {
           Monument monument = MonumentFactory.CreateMonument(monumentArgs);
            nations[type].AddMonument(monument);
        }
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation")
            .Append(this.nations[nationsType]);

        return sb.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        foreach (var nation in nations.OrderByDescending(x => x.Value.CalculatePower()).Skip(1))
        {
            nation.Value.ClearArmy();
        }

        this.pastWars.Add($"War {this.pastWars.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var war in pastWars)
        {
            sb.AppendLine(war);
        }
        return sb.ToString().TrimEnd();
    }
}