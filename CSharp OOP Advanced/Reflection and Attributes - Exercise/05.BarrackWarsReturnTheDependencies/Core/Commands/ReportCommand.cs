using System;
using System.Collections.Generic;
using System.Text;
using _05.BarrackWarsReturnTheDependencies.Contracts;

namespace _05.BarrackWarsReturnTheDependencies.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}