using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private const string baseClassName = "Harvester";

    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];

        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        Type clazz = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + baseClassName);
        var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        IHarvester harvester = (IHarvester)ctors[0].Invoke(new object[] { id, oreOutput, energyReq });
        return harvester;
    }
}