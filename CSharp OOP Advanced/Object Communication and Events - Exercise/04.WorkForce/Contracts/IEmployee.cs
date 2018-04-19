using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WorkForce.Contracts
{
    public interface IEmployee
    {
        string Name { get; }
        int HoursPerWeek { get; }
    }
}
