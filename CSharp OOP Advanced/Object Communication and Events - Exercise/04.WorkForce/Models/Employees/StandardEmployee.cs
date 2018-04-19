using System;
using System.Collections.Generic;
using System.Text;
using _04.WorkForce.Contracts;

namespace _04.WorkForce
{
    public class StandardEmployee : IEmployee
    {
        public StandardEmployee(string name)
        {
            this.Name = name;
            this.HoursPerWeek = 40;
        }

        public string Name { get; private set; }

        public int HoursPerWeek { get; private set; }
    }
}
