using System;

namespace _02.KingsGambit
{
    public abstract class Soldier
    {
        public string Name { get; private set; }

        protected Soldier(string name)
        {
            this.Name = name;
        }

        public abstract void KindUnderAttack(object sender, EventArgs e);
    }
}