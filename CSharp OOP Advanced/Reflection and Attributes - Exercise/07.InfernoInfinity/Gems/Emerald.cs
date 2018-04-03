using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Gems
{
    public class Emerald : Gem
    {
        private const int strength = 1;
        private const int agility = 4;
        private const int vitalit = 9;

        public Emerald(string clarity) : base(clarity, strength, agility, vitalit)
        {
        }
    }
}
