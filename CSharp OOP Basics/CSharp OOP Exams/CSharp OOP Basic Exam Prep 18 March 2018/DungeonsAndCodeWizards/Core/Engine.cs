using DungeonsAndCodeWizards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    DungeonMaster dungeonMaster;

    public Engine()
    {
        dungeonMaster = new DungeonMaster();
    }

    public void Run()
    {
        while (!dungeonMaster.IsGameOver())
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                break;
            }

            ExecuteCommand(input);
        }

        Console.WriteLine("Final stats:" + Environment.NewLine + dungeonMaster.GetStats());
    }

    private void ExecuteCommand(string input)
    {
        string[] commandArg = input.Split(" ");
        string command = commandArg[0];
        commandArg = commandArg.Skip(1).ToArray();

        try
        {
            switch (command)
            {
                case "JoinParty":
                    Console.WriteLine(dungeonMaster.JoinParty(commandArg));
                    break;
                case "AddItemToPool":
                    Console.WriteLine(dungeonMaster.AddItemToPool(commandArg));
                    break;
                case "PickUpItem":
                    Console.WriteLine(dungeonMaster.PickUpItem(commandArg));
                    break;
                case "UseItem":
                    Console.WriteLine(dungeonMaster.UseItem(commandArg));
                    break;
                case "UseItemOn":
                    Console.WriteLine(dungeonMaster.UseItemOn(commandArg));
                    break;
                case "GiveCharacterItem":
                    Console.WriteLine(dungeonMaster.GiveCharacterItem(commandArg));
                    break;
                case "GetStats":
                    Console.WriteLine(dungeonMaster.GetStats());
                    break;
                case "Attack":
                    Console.WriteLine(dungeonMaster.Attack(commandArg));
                    break;
                case "Heal":
                    Console.WriteLine(dungeonMaster.Heal(commandArg));
                    break;
                case "EndTurn":
                    Console.WriteLine(dungeonMaster.EndTurn(commandArg));
                    break;
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Parameter Error: {e.Message}");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Invalid Operation: {e.Message}");
        }
    }
}