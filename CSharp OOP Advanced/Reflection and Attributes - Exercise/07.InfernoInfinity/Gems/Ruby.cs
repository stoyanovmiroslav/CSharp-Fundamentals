using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Gems
{
    public class Ruby : Gem
    {
        private const int strength = 7;
        private const int agility = 2;
        private const int vitalit = 5;

        public Ruby(string clarity) : base(clarity, strength, agility, vitalit)
        {
        }
    }
}