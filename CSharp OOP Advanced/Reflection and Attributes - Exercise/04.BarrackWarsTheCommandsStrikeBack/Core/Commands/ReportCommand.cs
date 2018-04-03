using System;
using System.Collections.Generic;
using System.Text;
using _04.BarrackWarsTheCommandsStrikeBack.Contracts;
using _04.BarrackWarsTheCommandsStrikeBack.Core.Commands;

namespace _04.BarrackWarsTheCommandsStrikeBack.Core.Commands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}