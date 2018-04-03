using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var assembly = Assembly.GetCallingAssembly();
            var currentUnit = assembly.GetTypes().FirstOrDefault(c => c.Name == unitType);

            IUnit instance = (IUnit)Activator.CreateInstance(currentUnit, true);

            return instance;
        }
    }
}
