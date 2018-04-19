using System;
using System.Collections.Generic;
using System.Text;

namespace _05.KingsGambitExtended
{
    public class King
    {
        public event EventHandler UnderAttack;
        private string name;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void OnUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.UnderAttack?.Invoke(this, new EventArgs());
        }
    }
}
