using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warsArchive;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation() },
            {"Fire", new Nation() },
            {"Earth", new Nation() },
            {"Water", new Nation() }
        };
        this.warsArchive = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        //Bender {type} {name} {power} {secondaryParameter}
        try
        {
            var benderType = benderArgs[0];
            Bender newBender = BenderFactory.CreateBender(benderArgs);

            nations[benderType].AddBender(newBender);
        }
        catch (Exception)
        {
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        //Monument {type} {name} {affinity}
        try
        {
            var monumentType = monumentArgs[0];
            Monument newMonument = MonumentFactory.CreateMonument(monumentArgs);

            nations[monumentType].AddMonument(newMonument);
        }
        catch (Exception)
        {
        }
    }

    public string GetStatus(string nationsType)
    {
        //Status {nation}
        var sb = new StringBuilder();

        sb.AppendLine($"{nationsType} Nation")
            .Append(this.nations[nationsType]);


        return sb.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        //War {nation}
        var orderedNations = nations.Values.OrderByDescending(n => n.GetTotalPower()).Skip(1).ToList();

        foreach (var nation in orderedNations)
        {
            nation.ClearDefeatedArmy();
        }

        this.warsArchive.Add($"War {this.warsArchive.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.warsArchive);
    }
}