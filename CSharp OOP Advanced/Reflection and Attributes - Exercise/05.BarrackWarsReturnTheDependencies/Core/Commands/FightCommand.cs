using System;
using System.Collections.Generic;
using System.Text;
using _05.BarrackWarsReturnTheDependencies;

namespace _05.BarrackWarsReturnTheDependencies.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
