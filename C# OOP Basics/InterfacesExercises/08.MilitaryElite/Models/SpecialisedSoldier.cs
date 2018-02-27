using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, 
        string lastName, double salary, string corps) 
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.Corps}");

        return sb.ToString().Trim();
    }
}

