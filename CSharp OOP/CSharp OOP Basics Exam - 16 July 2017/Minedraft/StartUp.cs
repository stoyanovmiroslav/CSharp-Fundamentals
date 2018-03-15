using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        DraftManager dm = new DraftManager();

        string input = Console.ReadLine();
        while (input != "Shutdown")
        {
            string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();
            List<string> arguments = data.Skip(1).ToList();

            switch (data[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(dm.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(dm.RegisterProvider(arguments));
                    break;
                case "Day":
                    Console.WriteLine(dm.Day());
                    break;
                case "Mode":
                    Console.WriteLine(dm.Mode(arguments));
                    break;
                case "Check":
                    Console.WriteLine(dm.Check(arguments));
                    break;
            }

            input = Console.ReadLine();
        }
        Console.WriteLine(dm.ShutDown());
    }
}