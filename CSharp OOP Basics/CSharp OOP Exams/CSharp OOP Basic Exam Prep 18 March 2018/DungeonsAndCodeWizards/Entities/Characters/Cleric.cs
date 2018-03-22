using System;
using System.Collections.Generic;
using System.Text;

public class Cleric : Character, IHealable
{
    public Cleric(string name, Faction faction)
        : base(name, 50, 25, 40, new Backpack(), faction)
    {
        this.RestHealMultiplier = 0.5;
    }


    public void Heal(Character character)
    {
        this.EnsureAlive(this);
        this.EnsureAlive(character);

        if (this.Faction != character.Faction)
        {
            throw new InvalidOperationException("Cannot heal enemy character!");
        }
        character.Health += this.AbilityPoints;

    }
}
