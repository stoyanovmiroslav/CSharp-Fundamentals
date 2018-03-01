using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Interfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salari { get; }
    }
}