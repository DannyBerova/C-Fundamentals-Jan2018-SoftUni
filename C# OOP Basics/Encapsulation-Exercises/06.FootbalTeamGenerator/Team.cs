using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private const string NAME_ERROR = "A {0} should not be empty.";
    private const string REMOVE_PLAYER_ERROR = "Player {0} is not in {1} team.";

    private string name;
    private double rating;
    private ICollection<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.rating = 0;
        this.Players = new List<Player>();
    }

    public ICollection<Player> Players
    {
        get { return this.players; }
        set { this.players = value; }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(NAME_ERROR, nameof(this.name)));
            }

            this.name = value;
        }
    }

    public double Rating
    {
        get { return this.CalculateRating(); }
    }

    private double CalculateRating()
    {
        return this.Players.Any() ? this.Players.Average(p => p.OveralSkillLevel) : 0;
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var playerToBeRemoved = this.Players.FirstOrDefault(p => p.Name == playerName);

        if (playerToBeRemoved == null)
        {
            throw new ArgumentException(string.Format(REMOVE_PLAYER_ERROR, playerName, this.Name));
        }

        this.Players.Remove(playerToBeRemoved);
    }

    public override string ToString()
    {
        string result = $"{this.Name} - {this.Rating}";
        return result;
    }

}

