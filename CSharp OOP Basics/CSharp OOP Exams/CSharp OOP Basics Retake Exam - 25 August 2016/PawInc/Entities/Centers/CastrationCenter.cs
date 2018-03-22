using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CastrationCenter : Center
{
    protected Dictionary<string, List<Animal>> storedAnimals;
    private List<Animal> castratedAnimals;

    public CastrationCenter(string name)
    : base(name)
    {
        this.storedAnimals = new Dictionary<string, List<Animal>>();
        this.castratedAnimals = new List<Animal>();
    }

    public IReadOnlyCollection<Animal> CastratedAnimals => this.castratedAnimals as IReadOnlyCollection<Animal>;
    public IReadOnlyDictionary<string, List<Animal>> StoredAnimals => this.storedAnimals as IReadOnlyDictionary<string, List<Animal>>;
    public int countOfCastratedAnimals => castratedAnimals.Count();

    public void CastrateAnimals()
    {
        this.castratedAnimals.AddRange(this.Animals);
        this.Animals.Clear();
        this.storedAnimals.Clear();
    }

    public void AceptAnimals(string adoptionCenterName, List<Animal> animals)
    {
        if (!this.storedAnimals.ContainsKey(adoptionCenterName))
        {
            this.storedAnimals.Add(adoptionCenterName, new List<Animal>());
        }
        this.storedAnimals[adoptionCenterName].AddRange(animals);
        this.Animals.AddRange(animals);
    }
}