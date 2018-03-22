using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Contracts;

namespace _08.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, decimal salary, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Code Number: {this.CodeNumber}";
        }
    }
}
