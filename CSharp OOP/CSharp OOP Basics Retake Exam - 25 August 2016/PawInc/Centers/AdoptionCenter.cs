using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdoptionCenter : Center
{
    private List<Animal> adobdAnimals;

    public AdoptionCenter(string name) 
        : base(name)
    {
        this.AdobdAnimals = new List<Animal>();
    }

    public List<Animal> AdobdAnimals
    {
        get { return adobdAnimals; }
        private set { adobdAnimals = value; }
    }

    public void AddAnimals(List<Animal> animals)
    {
        this.Animals.AddRange(animals);
    }

    public void AdoptAnimals()
    {
        List<Animal> cleanAnimals = this.Animals.Where(a => a.CleansingStatus == "CLEANSED").ToList();
        List<Animal> uncleanAnimals = this.Animals.Where(a => a.CleansingStatus == "UNCLEANSED").ToList();
        this.Animals = new List<Animal>(uncleanAnimals);
        this.AdobdAnimals.AddRange(cleanAnimals);
    }

    public List<Animal> SendAllAnimals()
    {
        List<Animal> animals = new List<Animal>(this.Animals);
        this.Animals.Clear();
        return animals;
    }
}