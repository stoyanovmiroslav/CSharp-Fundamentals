using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CleansingCenter : Center
{
    protected Dictionary<string, List<Animal>> storedAnimals;
    private List<Animal> cleansedAnimals;

    public List<Animal> CleansedAnimals
    {
        get { return cleansedAnimals; }
        set { cleansedAnimals = value; }
    }

    public IReadOnlyDictionary<string, List<Animal>> StoredAnimals => this.storedAnimals as IReadOnlyDictionary<string, List<Animal>>;

    public int awaitingCleansing => this.Animals.Where(a => a.CleansingStatus == false).Count();

    public CleansingCenter(string name)
        : base(name)
    {
        this.storedAnimals = new Dictionary<string, List<Animal>>();
        this.CleansedAnimals = new List<Animal>();
    }

    public void AddAnimals(string adoptionCenterName, List<Animal> animals)
    {
        if (!this.storedAnimals.ContainsKey(adoptionCenterName))
        {
            this.storedAnimals.Add(adoptionCenterName, new List<Animal>());
        }

        this.storedAnimals[adoptionCenterName].AddRange(animals);
        this.Animals.AddRange(animals);
    }

    public void CleansingAnimals()
    {
        foreach (var center in storedAnimals)
        {
            foreach (var animal in center.Value)
            {
                animal.CleansingStatus = true;
            }
        }
    }

    public void SaveCleanedAnimals()
    {
        this.CleansedAnimals.AddRange(this.Animals);
        this.storedAnimals.Clear();
        this.Animals.Clear();
    }
}