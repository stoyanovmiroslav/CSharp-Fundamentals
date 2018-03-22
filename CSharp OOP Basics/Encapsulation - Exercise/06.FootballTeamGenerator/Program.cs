using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var teams = new Dictionary<string, Team>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                string[] teamInfo = input.Split(";");
                string command = teamInfo[0];
                string teamName = teamInfo[1];

                switch (command)
                {
                    case "Team":
                        AddNewTeam(teams, teamName);
                        break;
                    case "Add":
                        AddPlayer(teams, teamInfo, teamName);
                        break;
                    case "Remove":
                        RemovePlayer(teams, teamInfo, teamName);
                        break;
                    case "Rating":
                        GetRating(teams, teamName);
                        break;
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }

    private static void AddNewTeam(Dictionary<string, Team> teams, string teamName)
    {
        Team team = new Team(teamName);
        if (!teams.ContainsKey(teamName))
        {
            teams.Add(teamName, team);
        }
    }

    private static void GetRating(Dictionary<string, Team> teams, string teamName)
    {
        IsTeamExist(teams, teamName);
        Console.WriteLine("{0} - {1}", teams[teamName].Name, teams[teamName].CalculateRating());
    }

    private static void RemovePlayer(Dictionary<string, Team> teams, string[] teamInfo, string teamName)
    {
        IsTeamExist(teams, teamName);
        teams[teamName].RemovePlayers(teamInfo[2], teamInfo[1]);
    }

    private static void AddPlayer(Dictionary<string, Team> teams, string[] teamInfo, string teamName)
    {
        IsTeamExist(teams, teamName);
        Player player = new Player(teamInfo[2], double.Parse(teamInfo[3]), double.Parse(teamInfo[4]), double.Parse(teamInfo[5]), double.Parse(teamInfo[6]), double.Parse(teamInfo[7]));
        teams[teamName].AddPlayer(player);
    }

    private static void IsTeamExist(Dictionary<string, Team> teams, string teamName)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }
}