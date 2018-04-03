using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Weapons
{
    public class Sword : Weapon
    {
        private const int minDamage = 4;
        private const int maxDamage = 6;
        private const int bagGemCapacity = 3;

        public Sword(string name, string rarity) 
            : base(name, rarity, minDamage, maxDamage, bagGemCapacity)
        {
        }
    }
}
