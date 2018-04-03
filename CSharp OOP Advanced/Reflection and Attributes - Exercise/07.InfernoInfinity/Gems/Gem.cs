using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Gems
{
    public abstract class Gem
    {
        protected Gem(string clarity, int strength, int agility, int vitalit)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitalit;
            ModifiedGemStatus(clarity);
        }

        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Agility { get; set; }

        private void ModifiedGemStatus(string clarity)
        {
            if (Enum.TryParse(typeof(LevelClarity), clarity, out object levelClarity))
            {
                int increaseDamage = (int)levelClarity;

                this.Strength += increaseDamage;
                this.Agility += increaseDamage;
                this.Vitality += increaseDamage;
            }
        }
    }
}
