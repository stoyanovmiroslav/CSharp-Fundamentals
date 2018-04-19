using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvestes;
    private string mode;
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvestes = new List<IHarvester>();
        this.mode = "Full";
        this.harvesterFactory = new HarvesterFactory();
        this.energyRepository = energyRepository;
    }

    public string Mode => this.mode;

    public IReadOnlyCollection<IEntity> Entities => this.harvestes.AsReadOnly();

    public double OreProduced { get; set; }

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        foreach (var harvester in harvestes)
        {
            harvester.Broke();
        }

        this.harvestes = this.harvestes.Where(e => e.Durability >= 0).ToList();
        return string.Format(Constants.ChangeMode, mode);
    }

    public string Produce()
    {
        double neededEnergy = CalculataNeededEnergy();

        double minedOres = CalculataMinedOres(neededEnergy);

        this.OreProduced += minedOres;

        return string.Format(Constants.ProducedOreToday, minedOres);
    }

    private double CalculataMinedOres(double neededEnergy)
    {
        double minedOres = 0;

        if (this.energyRepository.EnergyStored >= neededEnergy)
        {
            this.energyRepository.TakeEnergy(neededEnergy);
            foreach (var harvester in this.harvestes)
            {
                minedOres += harvester.Produce();
            }
        }

        if (this.Mode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.Mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        return minedOres;
    }

    private double CalculataNeededEnergy()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvestes)
        {
            if (this.Mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.Mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.Mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        return neededEnergy;
    }

    public string Register(IList<string> args)
    {
        var type = args[0];
        var id = args[1];
        var oreOutput = double.Parse(args[2]);
        var energyRequirement = double.Parse(args[3]);
        var sonicFactor = 0;
        if (args.Count == 5)
        {
            sonicFactor = int.Parse(args[4]);
        }

        IHarvester harvester = harvesterFactory.GenerateHarvester(args);
        this.harvestes.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}