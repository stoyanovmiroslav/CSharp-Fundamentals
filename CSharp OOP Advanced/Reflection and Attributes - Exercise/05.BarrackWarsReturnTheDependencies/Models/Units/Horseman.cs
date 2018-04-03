using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BarrackWarsReturnTheDependencies.Models.Units
{
    public class Horseman : Unit
    {
        private const int DefaultHealth = 50;
        private const int DefaultDamage = 10;

        public Horseman() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
