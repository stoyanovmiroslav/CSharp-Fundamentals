using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = Modes.Full.ToString();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvest(arguments);
            harvesters.Add(harvester);
        }
        catch (ArgumentException argEx)
        {
            return $"Harvester is not registered, because of it's {argEx.Message}";
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Provider provider = ProviderFactory.CreateProvider(arguments);
            providers.Add(provider);
        }
        catch (ArgumentException argEx)
        {
            return $"Provider is not registered, because of it's {argEx.Message}";
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        double providedEnergyPerDay = providers.Sum(x => x.EnergyOutput);
        double requiredEnergyPerDay = harvesters.Sum(x => x.EnergyRequirement);

        double providedOrePerDay = 0;
        totalStoredEnergy += providedEnergyPerDay;

        if (totalStoredEnergy >= requiredEnergyPerDay)
        {
            if (mode == Modes.Full.ToString())
            {
                providedOrePerDay = harvesters.Sum(x => x.OreOutput);
                totalStoredEnergy -= requiredEnergyPerDay;
            }
            else if (mode == Modes.Half.ToString())
            {
                providedOrePerDay = harvesters.Sum(x => x.OreOutput) * 0.5;
                totalStoredEnergy -= requiredEnergyPerDay * 0.6;
            }
            totalMinedOre += providedOrePerDay;
        }

        return $"A day has passed.{Environment.NewLine}Energy Provided: {providedEnergyPerDay}{Environment.NewLine}Plumbus Ore Mined: {providedOrePerDay}";
    }

    public string Mode(List<string> arguments)
    {
        string newMode = arguments[0];
        bool switchMode = Enum.TryParse<Modes>(newMode, out Modes mode);

        if (switchMode)
        {
            this.mode = mode.ToString();
            return $"Successfully changed working mode to {this.mode} Mode";
        }
        else
        {
            return $"Unsuccessfully changed working mode to {this.mode} Mode";
        }

    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        var provider = providers.FirstOrDefault(x => x.Id == id);
        var harvester = harvesters.FirstOrDefault(x => x.Id == id);

        if (provider != null)
        {
            return provider.ToString();
        }
        else if (harvester != null)
        {
            return harvester.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return $"System Shutdown{Environment.NewLine}Total Energy Stored: {totalStoredEnergy}{Environment.NewLine}Total Mined Plumbus Ore: {totalMinedOre}";
    }
}