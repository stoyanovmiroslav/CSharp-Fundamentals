using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate 
    {
        Corps Corps { get; }
    }
}