using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using _05.BarrackWarsReturnTheDependencies.Contracts;
using _05.BarrackWarsReturnTheDependencies.Core.Commands;

namespace _05.BarrackWarsReturnTheDependencies.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var assembly = Assembly.GetCallingAssembly();
            var currentCommand = assembly.GetTypes().FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

            var fieldsToInject = currentCommand
                     .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                     .Where(f => f.CustomAttributes.Any(x => x.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject.Select(x => this.serviceProvider.GetService(x.FieldType)).ToArray();

            object[] ctorArgs = new object[] {data}.Concat(injectArgs).ToArray();

            IExecutable instance = (IExecutable)Activator.CreateInstance(currentCommand, ctorArgs);

            return instance;
        }
    }
}
