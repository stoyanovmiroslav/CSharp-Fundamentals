using System;
using System.Collections.Generic;
using System.Text;
using _07.InfernoInfinity.Gems;

namespace _07.InfernoInfinity.Weapons
{
    public class Axe : Weapon
    {
        private const int minDamage = 5;
        private const int maxDamage = 10;
        private const int bagGemCapacity = 4;

        public Axe(string name, string rarity)
            : base(name, rarity, minDamage, maxDamage, bagGemCapacity)
        {
        }
    }
}
