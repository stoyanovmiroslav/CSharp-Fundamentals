using System;
using System.Linq;

public class Engine
{
    private IReader consoleReader;
    private IWriter consoleWriter;
    private ICommandInterpreter commandInterpreter;

    public Engine(CommandInterpreter commandInterpreter, IReader consoleReader, IWriter consoleWriter)
    {
        this.commandInterpreter = commandInterpreter;
        this.consoleReader = consoleReader;
        this.consoleWriter = consoleWriter;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var input = consoleReader.ReadLine();
         
            var data = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            this.consoleWriter.WriteLine(commandInterpreter.ProcessCommand(data));

            if (data[0] == "Shutdown")
            {
                isRunning = false;
            }
        }
    }
}
