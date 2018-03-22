using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Contracts
{
   public interface ILeutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Private { get; } // ISoldier colection
        void AddPrivate(ISoldier soldier);             // not sure
    }
}
