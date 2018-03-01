using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Team
{
    private string name;
    private List<Player> players;

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayers(string player, string team)
    {
        if (players.Any(x => x.Name == player))
        {
            var currentPlayer = players.First(x => x.Name == player);
            this.players.Remove(currentPlayer);
        }
        else
        {
            throw new ArgumentException($"Player {player} is not in {team} team.");
        }
    }

    public double CalculateRating()
    {
        if (this.players.Count == 0)
        {
            return 0;
        }
        return Math.Round(this.players.Select(p => p.Stars).Average());
    }

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public IReadOnlyCollection<Player> Players
    {
        get { return players; }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
}