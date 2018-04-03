using System.Linq;
using System.Reflection;

namespace _04.BarrackWarsTheCommandsStrikeBack.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
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
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;

            var assembly = Assembly.GetCallingAssembly();
            var currentCommand = assembly.GetTypes().FirstOrDefault(c => c.Name.ToLower() == commandName + "command");
            IExecutable instance = (IExecutable)Activator.CreateInstance(currentCommand, new object[] { data, this.repository, this.unitFactory });

            return instance.Execute();
        }
    }
}
