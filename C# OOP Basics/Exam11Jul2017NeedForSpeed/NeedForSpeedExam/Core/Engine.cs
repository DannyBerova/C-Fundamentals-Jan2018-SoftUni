using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }

    public void Run()
    {
        string inputCommand;
        while ((inputCommand = Console.ReadLine()) != "Cops Are Here")
        {
            var commandArgs = ParseInput(inputCommand);
            DistributeCommands(commandArgs);
        }
    }

    private void DistributeCommands(List<string> commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.ToList();

        switch (command)
        {
            case "register":
                var id = int.Parse(commandArgs[1]);
                var type = commandArgs[2];
                var brand = commandArgs[3];
                var model = commandArgs[4];
                var year = int.Parse(commandArgs[5]);
                var horsepower = int.Parse(commandArgs[6]);
                var acceleration = int.Parse(commandArgs[7]);
                var suspension = int.Parse(commandArgs[8]);
                var durability = int.Parse(commandArgs[9]);
                this.manager.Register(id, type, brand, model, year, horsepower, acceleration, suspension, durability);
                break;
            case "check":
                OutputWriter(this.manager.Check(int.Parse(commandArgs[1])));
                break;
            case "open":
                var idRace = int.Parse(commandArgs[1]);
                var raceType = commandArgs[2];
                var length = int.Parse(commandArgs[3]);
                var route = commandArgs[4];
                var prizePool = int.Parse(commandArgs[5]);

                if (commandArgs.Count > 6)
                {
                    var extraParam = int.Parse(commandArgs[6]);
                    this.manager.Open(idRace, raceType, length, route, prizePool, extraParam);
                }
                else
                {
                    this.manager.Open(idRace, raceType, length, route, prizePool);
                }
                break;
            case "participate":
                var carId = int.Parse(commandArgs[1]);
                var raceId = int.Parse(commandArgs[2]);
                this.manager.Participate(carId, raceId);
                break;
            case "start":
                OutputWriter(this.manager.Start(int.Parse(commandArgs[1])));
                break;
            case "park":
                this.manager.Park(int.Parse(commandArgs[1]));
                break;
            case "unpark":
                this.manager.Unpark(int.Parse(commandArgs[1]));
                break;
            case "tune":
                this.manager.Tune(int.Parse(commandArgs[1]), commandArgs[2]);
                break;
        }
    }

    private void OutputWriter(string message) => Console.WriteLine(message);

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}
