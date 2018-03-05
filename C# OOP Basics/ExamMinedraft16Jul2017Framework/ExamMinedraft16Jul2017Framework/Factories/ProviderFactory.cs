using System;
using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider CreateProvider(List<string> args)
    {
        var typeOfProvider = args[0];
        var id = args[1];
        var energyOutput = double.Parse(args[2]);

        switch (typeOfProvider)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                throw new ArgumentException();
        }

    }
}

