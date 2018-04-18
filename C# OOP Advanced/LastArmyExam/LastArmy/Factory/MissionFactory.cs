using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == difficultyLevel);

        var missionConstructor = missionType.GetConstructor(new[] { typeof(double) });

        var argsToPass = new object[]
        {
            neededPoints
        };

        return (IMission)missionConstructor.Invoke(argsToPass);
    }
}