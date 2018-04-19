using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public class CommandInterpreter : ICommandInterpreter
{
    IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public string ProcessCommand(IList<string> data)
    {
        string command = data[0] + "Command";
        var assembly = Assembly.GetCallingAssembly();
        var currentCommand = assembly.GetTypes().FirstOrDefault(c => c.Name == command);

        var fieldsToInject = currentCommand
                 .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                 .Where(f => f.CustomAttributes.Any(x => x.AttributeType == typeof(InjectAttribute))).ToArray();

        object[] injectArgs = fieldsToInject.Select(x => this.serviceProvider.GetService(x.FieldType)).ToArray();
        object[] ctorArgs = new object[] { data.Skip(1).ToList() }.Concat(injectArgs).ToArray();
        ICommand instance = (ICommand)Activator.CreateInstance(currentCommand, ctorArgs);

        //Type type = Type.GetType(command);
        //var clazz = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == command);
        //object[] constr = new object[] { this, data.Skip(1).ToList() };
        //Command instance = (Command)Activator.CreateInstance(clazz, constr);

        return instance.Execute();
    }
}