using System;
using System.Collections.Generic;
using System.Text;

namespace _05.KingsGambitExtended
{
    public class Footman : Soldier
    {
        public Footman(string name) 
            : base(name)
        {
            this.hits = 2;
        }

        public override void KindUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}