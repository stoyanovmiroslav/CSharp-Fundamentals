using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    DraftManager draftManager;
    public Engine()
    {
        draftManager = new DraftManager();
    }

    public void Run()
    {
        string input = string.Empty;
        bool isRunning = true;

        while (isRunning)
        {
           List<string> commandArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = commandArgs[0];
            commandArgs.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(commandArgs));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(commandArgs));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(commandArgs));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(commandArgs));
                    break;
                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    isRunning = false;
                    break;
            }
        }
    }
}