using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, 
        double salary, string corps, IList<IRepair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public IList<IRepair> Repairs { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Repairs:");
        foreach (var rep in Repairs)
        {
            sb.AppendLine($"  {rep.ToString()}");
        }
        
        return sb.ToString().Trim();
    }
}

