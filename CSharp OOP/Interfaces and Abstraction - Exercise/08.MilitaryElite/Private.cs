using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base( id, firstName, lastName)
        {
            this.Salari = salary;
        }

        public decimal Salari { get; set; }

        public override string ToString()
        {
            return  $"{base.ToString()} Salary: {this.Salari:f2}";
        }
    }
}
