using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<ISoldier> army = new List<ISoldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var lineInfo = input.Split();
            switch (lineInfo[0])
            {
                case "Private":
                    army.Add(new Private(int.Parse(lineInfo[1]), lineInfo[2], lineInfo[3], double.Parse(lineInfo[4])));
                    break;

                case "Spy":
                    army.Add(new Spy(int.Parse(lineInfo[1]), lineInfo[2], lineInfo[3], int.Parse(lineInfo[4])));
                    break;

                case "LeutenantGeneral":
                    var privates = GetPrivates(lineInfo.Skip(5).ToList(), army);
                    army.Add(new LeutenantGeneral(int.Parse(lineInfo[1]), lineInfo[2], lineInfo[3], double.Parse(lineInfo[4]), privates));
                    break;

                case "Commando":
                    if (!(lineInfo[5] == "Marines" || lineInfo[5] == "Airforces"))
                    {
                        break;
                    }

                    var missions = GetValidMissions(lineInfo.Skip(6).ToList());
                    army.Add(new Commando(int.Parse(lineInfo[1]), lineInfo[2], lineInfo[3], double.Parse(lineInfo[4]), lineInfo[5], missions));
                    break;

                case "Engineer":
                    if (!(lineInfo[5] == "Marines" || lineInfo[5] == "Airforces"))
                    {
                        break;
                    }

                    var parts = GetRepairs(lineInfo.Skip(6).ToList());
                    army.Add(new Engineer(int.Parse(lineInfo[1]), lineInfo[2], lineInfo[3], double.Parse(lineInfo[4]), lineInfo[5], parts));
                    break;
            }
        }

        foreach (var soldier in army)
        {
            Console.WriteLine(soldier);
        }
    }

    private static IList<IRepair> GetRepairs(IList<string> parts)
    {
        var repairsList = new List<IRepair>();

        for (int i = 0; i < parts.Count - 1; i += 2)
        {
            repairsList.Add(new Repair(parts[i], int.Parse(parts[i + 1])));
        }

        return repairsList;
    }

    private static IList<IMission> GetValidMissions(IList<string> missions)
    {
        var missionsList = new List<IMission>();

        for (int i = 0; i < missions.Count - 1; i += 2)
        {
            if (missions[i + 1] != "inProgress" && missions[i + 1] != "Finished")
            {
                continue;
            }
            missionsList.Add(new Mission(missions[i], missions[i + 1]));
        }

        return missionsList;
    }

    private static IList<IPrivate> GetPrivates(IList<string> soldiers, IList<ISoldier> army)
    {
        var privatesList = new List<IPrivate>();

        foreach (var soldier in soldiers)
        {
            var soldierById = army.SingleOrDefault(s => s.Id == int.Parse(soldier));
            privatesList.Add((IPrivate)soldierById);
        }

        return privatesList;
    }
}

