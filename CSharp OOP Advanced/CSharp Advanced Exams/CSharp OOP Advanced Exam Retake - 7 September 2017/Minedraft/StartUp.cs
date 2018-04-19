using Microsoft.Extensions.DependencyInjection;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        IReader consoleReader = new ConsoleReader();
        IWriter consoleWriter = new ConsoleWriter();
        IServiceProvider serviceProvider = ConfigureServices();
        CommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

        Engine engine = new Engine(commandInterpreter, consoleReader, consoleWriter);
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<IHarvesterController, HarvesterController>();
        services.AddSingleton<IProviderController, ProviderController>();
        services.AddSingleton<IEnergyRepository, EnergyRepository>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}