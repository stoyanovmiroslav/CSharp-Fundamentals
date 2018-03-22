using System;
using System.Collections.Generic;
using System.Text;


public class PoisonPotion : Item
{
    private const int currentWeight = 5;

    public PoisonPotion()
        : base(currentWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (character.IsAlive)
        {
            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
        else
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}