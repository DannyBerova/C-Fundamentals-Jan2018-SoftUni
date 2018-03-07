using System;
using System.Collections.Generic;

public static class BenderFactory
{
    public static Bender CreateBender(List<string> benderArgs)
    {
        //Bender {type} {name} {power} {secondaryParameter}

        var benderType = benderArgs[0];
        var benderName = benderArgs[1];
        var benderPower = int.Parse(benderArgs[2]);
        var specificParam = double.Parse(benderArgs[3]);

        switch (benderType)
        {
            case "Air":
                return new AirBender(benderName, benderPower, specificParam);
            case "Water":
                return new WaterBender(benderName, benderPower, specificParam);
            case "Fire":
                return new FireBender(benderName, benderPower, specificParam);
            case "Earth":
                return new EarthBender(benderName, benderPower, specificParam);
            default:
                throw new ArgumentException();
        }
    }
}

