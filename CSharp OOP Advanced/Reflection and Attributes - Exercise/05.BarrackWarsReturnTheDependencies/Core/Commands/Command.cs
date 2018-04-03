using System;
using System.Collections.Generic;
using System.Text;
using _05.BarrackWarsReturnTheDependencies.Contracts;

namespace _05.BarrackWarsReturnTheDependencies.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public abstract string Execute();
    }
}
