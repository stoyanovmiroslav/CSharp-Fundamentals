using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Center
{
    private string name;
    private List<Animal> animals;

    protected Center(string name)
    {
        this.Name = name;
        this.Animals = new List<Animal>();
    }

    public int countOfAnimals => this.Animals.Where(x => x.CleansingStatus == true).Count();

    protected List<Animal> Animals
    {
        get { return animals; }
        set { animals = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public void AddAnimals(List<Animal> animals)
    {
        this.Animals.AddRange(animals);
    }

    public void AddAnimal(Animal animal)
    {
        this.Animals.Add(animal);
    }
}