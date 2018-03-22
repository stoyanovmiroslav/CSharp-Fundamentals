using System;
using System.Collections.Generic;
using System.Text;


public abstract class Character
{
    private string name;
    private double baseHealth;
    private double health;
    private double baseArmor;
    private double armor;
    private double abilityPoints;
    private Bag bag;
    private bool isAlive;
    private double restHealMultiplier;
    private Faction faction;

    public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.BaseArmor = armor;
        this.Armor = armor;
        this.BaseHealth = health;
        this.Health = health;

        this.IsAlive = true;
        this.RestHealMultiplier = 0.2;
        this.Name = name;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
    }

    public void TakeDamage(double hitPoints)
    {
        EnsureAlive(this);

        double diff = this.Armor - hitPoints;
        this.Armor -= hitPoints;

        if (diff < 0)
        {
            diff = Math.Abs(diff);
            this.Health = this.Health - diff;

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }

    public void Rest()
    {
        EnsureAlive(this);
        this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);
    }

    public void UseItem(Item item)
    {
        EnsureAlive(this);
        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        EnsureAlive(this);
        EnsureAlive(character);
        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        EnsureAlive(this);
        EnsureAlive(character);
        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        EnsureAlive(this);
        this.Bag.AddItem(item);
    }

    protected void EnsureAlive(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }

    public Faction Faction
    {
        get { return faction; }
        set { faction = value; }
    }

    public double RestHealMultiplier
    {
        get { return restHealMultiplier; }
        set { restHealMultiplier = value; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    public Bag Bag
    {
        get { return bag; }
        set { bag = value; }
    }

    public double AbilityPoints
    {
        get { return abilityPoints; }
        set { abilityPoints = value; }
    }

    public double Armor
    {
        get { return armor; }
        set
        {
            if (value > this.BaseArmor)
            {
                value = this.BaseArmor;
            }
            if (value < 0)
            {
                value = 0;
            }
            armor = value;
        }
    }


    public double BaseArmor
    {
        get { return baseArmor; }
        set { baseArmor = value; }
    }

    public double Health
    {
        get { return health; }
        set
        {
            if (value > this.BaseHealth)
            {
                value = this.BaseHealth;
            }
            if (value < 0)
            {
                value = 0;
            }
            health = value;
        }
    }

    public double BaseHealth
    {
        get { return baseHealth; }
        set { baseHealth = value; }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            name = value;
        }
    }

    public override string ToString()
    {
        string isAliveDead = "";
        if (isAlive)
        {
            isAliveDead = "Alive";
        }
        else
        {
            isAliveDead = "Dead";
        }

        string result = $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {isAliveDead}";
        return result;
    }
}
