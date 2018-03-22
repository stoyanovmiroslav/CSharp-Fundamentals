using System;
using System.Collections.Generic;
using System.Text;


public class HealthPotion : Item
{
    private const int currentWeight = 5;

    public HealthPotion()
        : base(currentWeight) //currentWeight
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (character.IsAlive)
        {
            character.Health += 20;
        }
        else
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
