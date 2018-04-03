using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Gems
{
    public class Amethyst : Gem
    {
        private const int strength = 2;
        private const int agility = 8;
        private const int vitalit = 4;

        public Amethyst(string clarity) : base(clarity, strength, agility, vitalit)
        {
        }
    }
}