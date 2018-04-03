using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BarrackWarsReturnTheDependencies.Models.Units
{
    public class Gunner : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 20;

        public Gunner()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}