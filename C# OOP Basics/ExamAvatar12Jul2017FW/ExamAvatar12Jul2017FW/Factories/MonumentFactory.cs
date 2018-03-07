using System;
using System.Collections.Generic;

public static class MonumentFactory
{
    internal static Monument CreateMonument(List<string> monumentArgs)
    {
        //Monument {type} {name} {affinity}

        var monumentType = monumentArgs[0];
        var monumentName = monumentArgs[1];
        var specificParam = int.Parse(monumentArgs[2]);

        switch (monumentType)
        {
            case "Air":
                return new AirMonument(monumentName, specificParam);
            case "Water":
                return new WaterMonument(monumentName, specificParam);
            case "Fire":
                return new FireMonument(monumentName, specificParam);
            case "Earth":
                return new EarthMonument(monumentName, specificParam);
            default:
                throw new ArgumentException();
        }
    }
}

