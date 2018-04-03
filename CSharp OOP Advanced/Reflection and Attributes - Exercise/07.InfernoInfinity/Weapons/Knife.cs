
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Weapons
{
    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;
        private const int bagGemCapacity = 2;

        public Knife(string name, string rarity)
            : base(name, rarity, minDamage, maxDamage, bagGemCapacity)
        {
        }
    }
}
