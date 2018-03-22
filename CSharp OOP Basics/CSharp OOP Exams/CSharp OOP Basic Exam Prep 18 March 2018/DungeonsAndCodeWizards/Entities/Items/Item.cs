using System;
using System.Collections.Generic;
using System.Text;

public abstract class Item
{
    private int weight;

    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public abstract void AffectCharacter(Character character);

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }
}