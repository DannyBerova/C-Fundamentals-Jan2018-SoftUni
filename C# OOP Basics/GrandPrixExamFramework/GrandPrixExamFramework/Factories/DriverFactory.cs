using System;
using System.Collections.Generic;
using System.Linq;

public static class DriverFactory
{
    public static Driver CreateDriver(List<string> commandArgs)
    {
        Driver driver;

        var type = commandArgs[0];
        var name = commandArgs[1];
        var hp = int.Parse(commandArgs[2]);
        var fuelAmount = double.Parse(commandArgs[3]);

        var args = commandArgs.Skip(4).ToList();
        var tyre = TyreFactory.CreateTyre(args);

        var car = new Car(hp, fuelAmount, tyre);

        if (type == "Aggressive")
        {
            driver = new AggressiveDriver(name, car);
        }
        else if (type == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
        }
        else
	{
            throw new ArgumentException();
        }

        return driver;
    }
}
