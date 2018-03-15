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
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParameter = double.Parse(benderArgs[3]);

        if (nations.ContainsKey(type))
        {
            Bender bender = null;
            switch (type)
            {
                case "Air":
                    AirBender airBender = new AirBender(name, power, secondaryParameter);
                    bender = airBender;
                    break;
                case "Water":
                    WaterBender waterBender = new WaterBender(name, power, secondaryParameter);
                    bender = waterBender;
                    break;
                case "Fire":
                    FireBender fireBender = new FireBender(name, power, secondaryParameter);
                    bender = fireBender;
                    break;
                case "Earth":
                    EarthBender earthBender = new EarthBender(name, power, secondaryParameter);
                    bender = earthBender;
                    break;
            }
            nations[type].AddBender(bender);
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        if (nations.ContainsKey(type))
        {
            Monument monument = null;
            switch (type)
            {
                case "Air":
                    AirMonument airMonument = new AirMonument(name, affinity);
                    monument = airMonument;
                    break;
                case "Water":
                    WaterMonument waterMonument = new WaterMonument(name, affinity);
                    monument = waterMonument;
                    break;
                case "Fire":
                    FireMonument fireMonument = new FireMonument(name, affinity);
                    monument = fireMonument;
                    break;
                case "Earth":
                    EarthMonument earthMonument = new EarthMonument(name, affinity);
                    monument = earthMonument;
                    break;
            }
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