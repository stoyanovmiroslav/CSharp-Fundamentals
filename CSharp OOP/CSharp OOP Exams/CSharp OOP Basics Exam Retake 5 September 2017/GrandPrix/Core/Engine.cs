using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int numberOfTheLaps = int.Parse(Console.ReadLine());
        int lengthOfTheTrack = int.Parse(Console.ReadLine());

        raceTower.SetTrackInfo(numberOfTheLaps, lengthOfTheTrack);

        while (numberOfTheLaps > raceTower.currentLaps)
        {
            List<string> command = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> commandArgs = command.Skip(1).ToList();

            switch (command[0])
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(commandArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    PrintOutput(raceTower.CompleteLaps(commandArgs));
                    break;
                case "Box":
                    raceTower.DriverBoxes(commandArgs);
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(commandArgs);
                    break;
            }
        }
        PrintOutput(raceTower.PrintWinner());
    }

    private void PrintOutput(string output)
    {
        if (output != string.Empty)
        {
            Console.WriteLine(output);
        }
    }
}