using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    NationsBuilder nationsBuilder;

    public Engine()
    {
        nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "Quit")
        {
            List<string> splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = splitInput[0];
            splitInput.RemoveAt(0);

            switch (command)
            {
                case "Bender":
                    nationsBuilder.AssignBender(splitInput);
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(splitInput);
                    break;
                case "Status":
                    PrintOutput(nationsBuilder.GetStatus(splitInput[0]));
                    break;
                case "War":
                    nationsBuilder.IssueWar(splitInput[0]);
                    break;
            }
        }
        string record = nationsBuilder.GetWarsRecord();
        PrintOutput(record);
    }

    private void PrintOutput(string output)
    {
        Console.WriteLine(output);
    }
}
