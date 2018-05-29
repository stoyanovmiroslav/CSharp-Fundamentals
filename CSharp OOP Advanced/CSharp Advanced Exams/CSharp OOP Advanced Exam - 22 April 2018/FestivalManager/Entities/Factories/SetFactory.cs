using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type setType = this.getType(type);
            return (ISet)Activator.CreateInstance(setType, name);
        }

        private Type getType(string ammunitionName)
        {
            Type[] assemblyTypes = Assembly
                .GetCallingAssembly()
                .GetTypes();

            return assemblyTypes.FirstOrDefault(t => t.Name == ammunitionName);
        }
    }
}
