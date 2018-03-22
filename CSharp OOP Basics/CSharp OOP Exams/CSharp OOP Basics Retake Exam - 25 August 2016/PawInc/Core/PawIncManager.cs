using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PawIncManager
{
    private List<AdoptionCenter> adoptionCenters;
    private List<CleansingCenter> cleansingCenters;
    private List<CastrationCenter> castrationCenters;


    public PawIncManager()
    {
        this.adoptionCenters = new List<AdoptionCenter>();
        this.cleansingCenters = new List<CleansingCenter>();
        this.castrationCenters = new List<CastrationCenter>();
    }

    public void RegisterAdoptionCenter(string name)
    {
        AdoptionCenter adoptionCenter = new AdoptionCenter(name);
        adoptionCenters.Add(adoptionCenter);
    }

    public void RegisterCleansingCenter(string name)
    {
        CleansingCenter cleansingCenter = new CleansingCenter(name);
        cleansingCenters.Add(cleansingCenter);
    }

    public void RegisterCastrationCenter(string name)
    {
        CastrationCenter castrationCenter = new CastrationCenter(name);
        castrationCenters.Add(castrationCenter);
    }

    public void RegisterCat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
    {
        Cat cat = new Cat(name, age, intelligenceCoefficient);
        var adoptionCenterForCat = adoptionCenters.FirstOrDefault(c => c.Name == adoptionCenterName);
        if (adoptionCenterForCat != null)
        {
            adoptionCenterForCat.AddAnimal(cat);
        }
    }

    public void RegisterDog(string name, int age, int learnedCommands, string adoptionCenterName)
    {
        Dog dog = new Dog(name, age, learnedCommands);
        var adoptionCenterForDog = adoptionCenters.FirstOrDefault(c => c.Name == adoptionCenterName);
        if (adoptionCenterForDog != null)
        {
            adoptionCenterForDog.AddAnimal(dog);
        }
    }

    public void SendForCastration(string adoptionCenterName, string castrationCenterName)
    {
        var currentAdoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoptionCenterName);
        var currentCastrationCenter = castrationCenters.FirstOrDefault(c => c.Name == castrationCenterName);

        if (currentAdoptionCenter != null && currentCastrationCenter != null)
        {
            currentCastrationCenter.AceptAnimals(adoptionCenterName, currentAdoptionCenter.GetAllAnimals());
        }
    }

    public void Castrate(string castrationCenterName)
    {
        var currentCastrationCenter = castrationCenters.FirstOrDefault(c => c.Name == castrationCenterName);

        if (currentCastrationCenter != null)
        {
            foreach (var center in currentCastrationCenter.StoredAnimals)
            {
                var currentAdoptionCenters = adoptionCenters.FirstOrDefault(a => a.Name == center.Key);
                if (currentAdoptionCenters != null)
                {
                    currentAdoptionCenters.AddAnimals(center.Value);
                }
            }
            currentCastrationCenter.CastrateAnimals();
        }
    }

    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
    {
        var currentAdoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoptionCenterName);
        var currentCleansingCenterName = cleansingCenters.FirstOrDefault(c => c.Name == cleansingCenterName);

        if (currentAdoptionCenter != null && currentCleansingCenterName != null)
        {
            currentCleansingCenterName.AddAnimals(adoptionCenterName, currentAdoptionCenter.GetUncleansedAnimals());
        }
    }

    public void Cleanse(string cleansingCenterName)
    {
        var currentCleansingCenter = cleansingCenters.FirstOrDefault(c => c.Name == cleansingCenterName);

        if (currentCleansingCenter != null)
        {
            currentCleansingCenter.CleansingAnimals();
            foreach (var center in currentCleansingCenter.StoredAnimals)
            {
                var currentAdoptionCenter = adoptionCenters.FirstOrDefault(a => a.Name == center.Key);
                if (currentAdoptionCenter != null)
                {
                    currentAdoptionCenter.AddAnimals(center.Value);
                }
            }
            currentCleansingCenter.SaveCleanedAnimals();
        }
    }

    public void Adopt(string adoptionCenterName)
    {
        var currentAdoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoptionCenterName);
        if (currentAdoptionCenter != null)
        {
            currentAdoptionCenter.AdoptCleansedAnimals();
        }
    }

    public string CastrationStatistics()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Paw Inc. Regular Castration Statistics")
                     .AppendLine($"Castration Centers: {castrationCenters.Count}");

        if (castrationCenters.Any(x => x.countOfCastratedAnimals > 0))
        {
            List<Animal> castratedAnimals = GetCastratedAnimals();
            stringBuilder.AppendLine("Castrated Animals: " + string.Join(", ", castratedAnimals.OrderBy(x => x.Name)));
        }
        else
        {
            stringBuilder.AppendLine("Castrated Animals: None");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    private List<Animal> GetCastratedAnimals()
    {
        List<Animal> castratedAnimals = new List<Animal>();
        foreach (var center in castrationCenters)
        {
            if (center.CastratedAnimals.Count > 0)
            {
                castratedAnimals.AddRange(center.CastratedAnimals);
            }
        }

        return castratedAnimals;
    }

    private List<Animal> GetCleansedAnimals()
    {
        List<Animal> cleansedAnimals = new List<Animal>();
        foreach (var center in cleansingCenters)
        {
            if (center.CleansedAnimals.Count > 0)
            {
                cleansedAnimals.AddRange(center.CleansedAnimals);
            }
        }

        return cleansedAnimals;
    }

    private List<Animal> GetAdoptedAnimals()
    {
        List<Animal> adoptedAnimals = new List<Animal>();
        foreach (var center in adoptionCenters)
        {
            if (center.AdoptedAnimals.Count > 0)
            {
                adoptedAnimals.AddRange(center.AdoptedAnimals);
            }
        }

        return adoptedAnimals;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Paw Incorporative Regular Statistics")
                     .AppendLine($"Adoption Centers: {adoptionCenters.Count}")
                     .AppendLine($"Cleansing Centers: {cleansingCenters.Count}");

        if (adoptionCenters.Any(x => x.AdoptedAnimals.Count > 0))
        {
            List<Animal> adoptedAnimals = GetAdoptedAnimals();
            stringBuilder.AppendLine("Adopted Animals: " + string.Join(", ", adoptedAnimals.OrderBy(x => x.Name)));
        }
        else
        {
            stringBuilder.AppendLine("Adopted Animals: None");
        }

        if (cleansingCenters.Any(x => x.CleansedAnimals.Count > 0))
        {
            List<Animal> cleansedAnimals = GetCleansedAnimals();
            stringBuilder.AppendLine("Cleansed Animals: " + string.Join(", ", cleansedAnimals.OrderBy(x => x.Name)));
        }
        else
        {
            stringBuilder.AppendLine("Cleansed Animals: None");
        }

        int adoprionCount = adoptionCenters.Select(x => x.countOfAnimals).Sum();
        int cleansingCount = cleansingCenters.Select(x => x.awaitingCleansing).Sum();

        stringBuilder.AppendLine($"Animals Awaiting Adoption: {adoprionCount}");
        stringBuilder.AppendLine($"Animals Awaiting Cleansing: {cleansingCount}");

        return stringBuilder.ToString().TrimEnd();
    }
}