using System;
using System.Collections.Generic;
using System.Text;

namespace _05.KingsGambitExtended
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) 
            : base(name)
        {
            this.hits = 3;
        }

        public override void KindUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
