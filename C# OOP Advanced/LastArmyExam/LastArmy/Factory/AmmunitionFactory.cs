using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammunitionType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == ammunitionName);

        var ammunitionConstructor = ammunitionType.GetConstructor(new[] { typeof(string) });

        return (IAmmunition)ammunitionConstructor.Invoke(new object[] { ammunitionName });
    }
}