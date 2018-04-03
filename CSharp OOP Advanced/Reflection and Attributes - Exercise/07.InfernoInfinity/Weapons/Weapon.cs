using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07.InfernoInfinity.Gems;

namespace _07.InfernoInfinity.Weapons
{
    public abstract class Weapon
    {
        private string name;
        private int minDamage;
        private int maxDamage;
        private Gem[] bagGem;

        protected Weapon(string name, string rarity, int minDamage, int maxDamage, int bagGemCapacity)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.bagGem = new Gem[bagGemCapacity];
            ModifiedDamageRarity(rarity);
        }

        private void ModifiedDamageRarity(string rarity)
        {
            if (Enum.TryParse(typeof(LevelRarity), rarity , out object levelRarity))
            {
                int increaseDamage = (int)levelRarity;
                this.MinDamage *= increaseDamage;
                this.MaxDamage *= increaseDamage;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Gem[] BagGem
        {
            get { return bagGem; }
            set { bagGem = value; }
        }

        public int MaxDamage
        {
            get { return maxDamage; }
            set { maxDamage = value; }
        }

        public int MinDamage
        {
            get { return minDamage; }
            set { minDamage = value; }
        }

        public void Add(int index, Gem gem)
        {
            if (index >= 0 && index < this.bagGem.Length)
            {
                bagGem[index] = gem;
            }
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < this.bagGem.Length)
            {
                bagGem[index] = null;
            }
        }

        public override string ToString()
        {
            int agilitySum = this.BagGem.Where(g => g != null).Select(g => g.Agility).Sum();
            int strengthSum = this.BagGem.Where(g => g != null).Select(g => g.Strength).Sum();
            int vitalitySum = this.BagGem.Where(g => g != null).Select(g => g.Vitality).Sum();

            int minSumDamage = this.MinDamage + (2 * strengthSum) + agilitySum;
            int maxSumDamage = this.MaxDamage + (3 * strengthSum) + (4 * agilitySum);

            return $"{this.Name}: {minSumDamage}-{maxSumDamage} Damage, +{strengthSum} Strength, +{agilitySum} Agility, +{vitalitySum} Vitality";
        }
    }
}