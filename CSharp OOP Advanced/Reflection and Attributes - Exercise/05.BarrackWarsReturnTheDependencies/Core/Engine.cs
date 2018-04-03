using System.Linq;
using System.Reflection;

namespace _05.BarrackWarsReturnTheDependencies.Core
{
    using System;
    using Contracts;

    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    IExecutable classInstance = commandInterpreter.InterpretCommand(data, commandName);
                    Console.WriteLine(classInstance.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}