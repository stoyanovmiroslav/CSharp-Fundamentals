using System;
using Microsoft.Extensions.DependencyInjection;
using _05.BarrackWarsReturnTheDependencies.Contracts;
using _05.BarrackWarsReturnTheDependencies.Core;
using _05.BarrackWarsReturnTheDependencies.Core.Factories;
using _05.BarrackWarsReturnTheDependencies.Data;

namespace _05.BarrackWarsReturnTheDependencies
{
    public class AppEntryPoint
    {
        static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}