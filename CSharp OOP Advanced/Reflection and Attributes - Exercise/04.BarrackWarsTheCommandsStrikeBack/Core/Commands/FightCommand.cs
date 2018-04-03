using System;
using System.Collections.Generic;
using System.Text;
using _04.BarrackWarsTheCommandsStrikeBack.Contracts;

namespace _04.BarrackWarsTheCommandsStrikeBack.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
