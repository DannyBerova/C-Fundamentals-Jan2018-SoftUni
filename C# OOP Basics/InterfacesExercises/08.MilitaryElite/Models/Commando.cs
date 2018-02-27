using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName,
        double salary, string corps, IList<IMission> missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public IList<IMission> Missions { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");
        foreach (var mision in Missions)
        {
            sb.AppendLine($"  {mision}");
        }

        return sb.ToString().Trim();
    }
}

