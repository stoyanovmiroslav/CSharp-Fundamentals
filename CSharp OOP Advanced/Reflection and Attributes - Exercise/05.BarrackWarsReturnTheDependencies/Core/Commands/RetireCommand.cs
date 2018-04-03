using System;
using System.Collections.Generic;
using System.Text;
using _05.BarrackWarsReturnTheDependencies.Contracts;

namespace _05.BarrackWarsReturnTheDependencies.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
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
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(this.Data[1]);
            string output = unitType + " retired!";
            return output;
        }
    }
}
