using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private readonly Dictionary<string, Driver> drivers;
    private readonly Dictionary<Driver, string> unfinishedDrivers;
    private int numberOfLaps;
    private int currentLap;
    private Weather weather;
    public Driver Winner { get; private set; }
    public int LenghtOfTrack { get; set; }
    public bool IsEndOfRace { get; private set; }

    public RaceTower()
    {
        this.drivers = new Dictionary<string, Driver>();
        this.unfinishedDrivers = new Dictionary<Driver, string>();
        this.weather = Weather.Sunny;
        this.currentLap = 0;
        this.IsEndOfRace = false;
    }

    public int NumberOfLaps
    {
        get => this.numberOfLaps;
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException($"There is no time! On lap {this.currentLap}.");
            }

            this.numberOfLaps = value;
        }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.NumberOfLaps = lapsNumber;
        this.LenghtOfTrack = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var name = commandArgs[1];
            var driver = DriverFactory.CreateDriver(commandArgs);
            drivers.Add(name, driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var boxCommand = commandArgs[0];
        var driverName = commandArgs[1];
        var givenParam = commandArgs[2];
        var driver = drivers[driverName];
        driver.TotalTime += 20;

        switch (boxCommand)
        {
            case "ChangeTyres":
                var args = commandArgs.Skip(2).ToList();
                var tyreToChange = TyreFactory.CreateTyre(args);
                driver.Car.ChangeTyre(tyreToChange);
                break;
            case "Refuel":
                driver.Car.Refuel(double.Parse(givenParam));
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var sb = new StringBuilder();
        var lapsToProcess = int.Parse(commandArgs[0]);

        try
        {
            this.NumberOfLaps -= lapsToProcess;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        for (int i = 0; i < lapsToProcess; i++)
        {
            ProcessDriverBeforeOvertaking();
            RemoveOutOfTheRaceDrivers();

            this.currentLap++;
            CheckAndPrintOvertakers(sb);
        }

        CheckIsEndOfTheRaceAndSetWinner();
        return sb.ToString().Trim();
    }

    private void CheckIsEndOfTheRaceAndSetWinner()
    {
        if (this.NumberOfLaps == 0)
        {
            this.IsEndOfRace = true;
            this.Winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
        }
    }

    private void CheckAndPrintOvertakers(StringBuilder sb)
    {
        var orderedDrivesToCheck = this.drivers
                        .Values
                        .OrderByDescending(d => d.TotalTime)
                        .ToList();

        //overtaking and print overtakers
        for (int count = 0; count < orderedDrivesToCheck.Count - 1; count++)
        {
            var first = orderedDrivesToCheck[count];
            var second = orderedDrivesToCheck[count + 1];

            var timeFirst = first.TotalTime;
            var timeSecond = second.TotalTime;

            var interval = 2;
            var difference = Math.Abs(timeFirst - timeSecond);
            bool hasCrashed = CheckForSpecialConditions(first, ref interval);

            if (difference <= interval)
            {
                if (hasCrashed)
                {
                    this.unfinishedDrivers.Add(first, "Crashed");

                    RemoveOutOfTheRaceDrivers();
                    continue;
                }

                first.TotalTime -= interval;
                second.TotalTime += interval;

                sb.AppendLine($"{first.Name} has overtaken {second.Name} on lap {this.currentLap}.");
            }
        }
        //endOvertaking
    }

    private bool CheckForSpecialConditions(Driver first, ref int interval)
    {
        bool hasCrashed = false;

        if (first.GetType().Name == "AggressiveDriver"
        && first.Car.Tyre.GetType().Name == "UltrasoftTyre")
        {
            interval = 3;
            if (this.weather == Weather.Foggy)
            {
                hasCrashed = true;
            }
        }

        if (first.GetType().Name == "EnduranceDriver"
        && first.Car.Tyre.GetType().Name == "HardTyre")
        {
            interval = 3;
            if (this.weather == Weather.Rainy)
            {
                hasCrashed = true;
            }
        }

        return hasCrashed;
    }

    private void RemoveOutOfTheRaceDrivers()
    {
        foreach (var crashDriver in this.unfinishedDrivers)
        {
            var searched = crashDriver.Key.Name;
            if (this.drivers.ContainsKey(searched))
            {
                this.drivers.Remove(searched);
            }
        }
    }

    private void ProcessDriverBeforeOvertaking()
    {
        foreach (var driver in drivers.Values)
        {
            driver.TotalTime += 60 / (this.LenghtOfTrack / driver.Speed);
            try
            {
                driver.ReduceFuelAmount(this.LenghtOfTrack);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (Exception ex)
            {
                this.unfinishedDrivers.Add(driver, ex.Message);
            }
        }
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();
        var counter = 1;
        sb.AppendLine($"Lap {this.currentLap}/{this.currentLap + this.NumberOfLaps}");

        foreach (var driver in this.drivers.Values.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{counter++} {driver.Name} {driver.TotalTime:F3}");
        }

        var crashesToPrint = this.unfinishedDrivers.Reverse();

        foreach (var driver in crashesToPrint)
        {
            sb.AppendLine($"{counter++} {driver.Key.Name} {driver.Value}");
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weatherToString = commandArgs[0];
        this.weather = (Weather)Enum.Parse(typeof(Weather), weatherToString);
    }
}
