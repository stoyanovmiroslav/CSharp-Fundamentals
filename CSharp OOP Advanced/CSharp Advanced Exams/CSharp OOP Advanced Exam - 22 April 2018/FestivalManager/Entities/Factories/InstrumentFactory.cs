namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
        public IInstrument CreateInstrument(string type)
        {
            Type instrumentsType = this.getType(type);
            return (IInstrument)Activator.CreateInstance(instrumentsType);
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