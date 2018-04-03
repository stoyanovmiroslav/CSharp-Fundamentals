using System;
using System.Collections.Generic;
using System.Text;
using _04.BarrackWarsTheCommandsStrikeBack.Contracts;

namespace _04.BarrackWarsTheCommandsStrikeBack.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(this.Data[1]);
            string output = unitType + " retired!";
            return output;
        }
    }
}
