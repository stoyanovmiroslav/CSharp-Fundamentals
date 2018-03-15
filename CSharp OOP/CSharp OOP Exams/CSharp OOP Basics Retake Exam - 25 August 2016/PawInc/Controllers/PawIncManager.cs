using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PawIncManager
{
    List<AdoptionCenter> adoptionCenters = new List<AdoptionCenter>();
    List<CleansingCenter> cleansingCenters = new List<CleansingCenter>();
    List<CastrationCenter> castrationCenters = new List<CastrationCenter>();

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
            currentCastrationCenter.AceptAnimals(adoptionCenterName, currentAdoptionCenter.SendAllAnimals());
        }
    }

    public void Adopt(string adoptionCenterName)
    {
        var currentAdoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoptionCenterName);
        if (currentAdoptionCenter != null)
        {
            currentAdoptionCenter.AdoptAnimals();
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

    public void CastrationStatistics()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Paw Inc. Regular Castration Statistics")
                     .AppendLine($"Castration Centers: {castrationCenters.Count}")
                     .Append("Castrated Animals: ");

        if (castrationCenters.Any(x => x.countOfCastratedAnimals > 0))
        {
            foreach (var center in castrationCenters)
            {
                stringBuilder.Append(string.Join(", ", center.CastratedAnimals.OrderBy(x => x.Name)));
            }
        }
        else
        {
            stringBuilder.Append("None");
        }

        Console.WriteLine(stringBuilder.ToString().TrimEnd());
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

    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
    {
        var currentAdoptionCenter = adoptionCenters.FirstOrDefault(c => c.Name == adoptionCenterName);
        var currentCleansingCenterName = cleansingCenters.FirstOrDefault(c => c.Name == cleansingCenterName);

        if (currentAdoptionCenter != null && currentCleansingCenterName != null)
        {
            currentCleansingCenterName.AddAnimals(adoptionCenterName, currentAdoptionCenter.SendAllAnimals());
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Paw Incorporative Regular Statistics")
                     .AppendLine($"Adoption Centers: {adoptionCenters.Count}")
                     .AppendLine($"Cleansing Centers: {cleansingCenters.Count}")
                     .Append("Adopted Animals: ");

        if (adoptionCenters.Any(x => x.AdobdAnimals.Count > 0))
        {
            foreach (var center in adoptionCenters)
            {
                stringBuilder.Append(string.Join(", ", center.AdobdAnimals.OrderBy(x => x.Name)));
            }
        }
        else
        {
            stringBuilder.Append("None");
        }

        stringBuilder.AppendLine();
        stringBuilder.Append("Cleansed Animals: ");

        if (cleansingCenters.Any(x => x.CleansedAnimals.Count > 0))
        {
            foreach (var center in cleansingCenters)
            {
                stringBuilder.Append(string.Join(", ", center.CleansedAnimals.OrderBy(x => x.Name)));
            }
        }
        else
        {
            stringBuilder.Append("None");
        }

        stringBuilder.AppendLine();
        int adoprionCount = adoptionCenters.Select(x => x.countOfAnimal).Sum();
        int cleansingCount = cleansingCenters.Select(x => x.AwaitingCleansing).Sum();

        stringBuilder.AppendLine($"Animals Awaiting Adoption: {adoprionCount}");
        stringBuilder.AppendLine($"Animals Awaiting Cleansing: {cleansingCount}");

        return stringBuilder.ToString().TrimEnd();
    }
}