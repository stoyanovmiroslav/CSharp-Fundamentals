using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdoptionCenter : Center
{
    private List<Animal> adoptedAnimals;

    public AdoptionCenter(string name) 
        : base(name)
    {
        this.AdoptedAnimals = new List<Animal>();
    }

    public List<Animal> AdoptedAnimals
    {
        get { return adoptedAnimals; }
        private set { adoptedAnimals = value; }
    }

    public void AdoptCleansedAnimals()
    {
        List<Animal> cleanAnimals = this.Animals.Where(a => a.CleansingStatus == true).ToList();
        this.Animals = this.Animals.Where(a => a.CleansingStatus == false).ToList();
        this.AdoptedAnimals.AddRange(cleanAnimals);
    }

    public List<Animal> GetUncleansedAnimals()
    {
        List<Animal> uncleanAnimals = this.Animals.Where(a => a.CleansingStatus == false).ToList();
        this.Animals = this.Animals.Where(a => a.CleansingStatus == true).ToList();
        return uncleanAnimals;
    }

    public List<Animal> GetAllAnimals()
    {
        List<Animal> animals = new List<Animal>(this.Animals);
        this.Animals.Clear();
        return animals;
    }
}