using System;

namespace _05.KingsGambitExtended
{
    public abstract class Soldier
    {
        private bool isAlive;
        protected int hits;

        public string Name { get; private set; }

        protected Soldier(string name)
        {
            this.Name = name;
            this.isAlive = true;
        }

        public bool IsAlive
        {
            get { return isAlive; }
        }

        public abstract void KindUnderAttack(object sender, EventArgs e);

        public void TakeDamage()
        {
            this.hits--;
            if (hits == 0)
            {
                this.isAlive = false;
            }
        }
    }
}