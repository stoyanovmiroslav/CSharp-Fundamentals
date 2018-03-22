using System;
using System.Collections.Generic;
using System.Text;


public class Animal
{
    private string name;
    private string favouriteFood;

    public Animal(string name, string favoriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favoriteFood;
    }

    public string FavouriteFood
    {
        get { return favouriteFood; }
        set { favouriteFood = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public virtual string ExplainSelf()
    {
        return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
    }
}