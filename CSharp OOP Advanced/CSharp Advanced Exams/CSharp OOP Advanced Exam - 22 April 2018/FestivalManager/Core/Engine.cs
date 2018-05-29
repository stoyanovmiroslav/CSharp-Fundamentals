
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;
    
	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;
        
        private IFestivalController festivalCоntroller;
		private ISetController setCоntroller;
      

        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;

            this.reader = new StringReader();
            this.writer = new StringWriter();

        }

		
		public void Run()
		{
            bool isRunning = true;

			while (isRunning)
			{
				var input = reader.ReadLine();

				if (input == "END")
                {
                    isRunning = false;
                    break;
                }

				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

            var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var commandArgs = input.Split(" ".ToCharArray().First());

			var command = commandArgs.First();
			var args = commandArgs.Skip(1).ToArray();

			if (command == "LetsRock")
			{
				var setovete = this.setCоntroller.PerformSets();
				return setovete;
			}

            Type type = typeof(FestivalController);
			var festivalcontrolfunction = type.GetMethods().FirstOrDefault(x => x.Name == command);

			string result;

            try
            {
                result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller , new object[] { args });
            }
            catch (TargetInvocationException up)
            {
                throw up.InnerException;
            }

            return result;
		}
    }
}