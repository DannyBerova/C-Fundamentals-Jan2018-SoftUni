using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Start()
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var lengthOfTrack = int.Parse(Console.ReadLine());
        this.raceTower.SetTrackInfo(numberOfLaps, lengthOfTrack);

        string input = Console.ReadLine();

        while (true)
        {
            var commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var cmd = commandArgs.First();
            commandArgs.RemoveAt(0);

            ProcessCommand(commandArgs, cmd);

            if (this.raceTower.IsEndOfRace)
            {
                Console.WriteLine(
                    $"{this.raceTower.Winner.Name} wins the race for {this.raceTower.Winner.TotalTime:F3} seconds.");
                Environment.Exit(0);
            }

            input = Console.ReadLine();
        }
    }

    private void ProcessCommand(List<string> commandArgs, string cmd)
    {
        switch (cmd)
        {
            case "RegisterDriver":
                this.raceTower.RegisterDriver(commandArgs);
                break;
            case "Leaderboard":
                Console.WriteLine(this.raceTower.GetLeaderboard());
                break;
            case "CompleteLaps":
                var result = this.raceTower.CompleteLaps(commandArgs);
                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
                break;
            case "Box":
                this.raceTower.DriverBoxes(commandArgs);
                break;
            case "ChangeWeather":
                this.raceTower.ChangeWeather(commandArgs);
                break;
        }
    }
}