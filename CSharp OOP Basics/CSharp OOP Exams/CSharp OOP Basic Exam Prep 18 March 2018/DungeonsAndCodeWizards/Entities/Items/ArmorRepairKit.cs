using System;
using System.Collections.Generic;
using System.Text;

public class ArmorRepairKit : Item
{
    private const int currentWeight = 10;

    public ArmorRepairKit()
        : base(currentWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (character.IsAlive)
        {
            character.Armor = character.BaseArmor;
        }
        else
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
