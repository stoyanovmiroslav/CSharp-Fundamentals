using System;
using System.Collections.Generic;
using System.Text;
using _04.BarrackWarsTheCommandsStrikeBack.Contracts;

namespace _04.BarrackWarsTheCommandsStrikeBack.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
        }

        protected IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        protected string[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public abstract string Execute();
    }
}
