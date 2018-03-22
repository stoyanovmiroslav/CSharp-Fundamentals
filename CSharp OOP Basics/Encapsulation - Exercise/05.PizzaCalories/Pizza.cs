using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;
    private Dough doughs;
    private List<Topping> topping = new List<Topping>();

    public Pizza(string name)
    {
        this.Name = name;
    }

    private double ToppingsCalories
    {
        get
        {
            if (this.Topping.Count == 0)
            {
                return 0;
            }
            return this.topping.Select(t => t.Calories).Sum();
        }
    }

    public void AddTopping(Topping topping)
    {
        if (this.Topping?.Count >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.topping.Add(topping);
    }

    public IReadOnlyCollection<Topping> Topping
    {
        get { return topping; }
    }

    public Dough Dough
    {
        get { return doughs; }
        private set { doughs = value; }
    }

    public void SetDough(Dough dough)
    {
        if (this.Dough == null)
        {
            this.Dough = dough;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }
    private double Calories => this.Dough.Calories + this.ToppingsCalories;

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:F2} Calories.";
    }
}

