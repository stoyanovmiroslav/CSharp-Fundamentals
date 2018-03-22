using System;
using System.Collections.Generic;
using System.Text;

public class ItemFactory
{
    public Item CreateItem(string input)
    {
        switch (input)
        {
            case "HealthPotion":
                return new HealthPotion();
            case "PoisonPotion":
                return new PoisonPotion();
            case "ArmorRepairKit":
                return new ArmorRepairKit();
            default:
                throw new ArgumentException($"Invalid item \"{input}\"!");
        }
    }
}