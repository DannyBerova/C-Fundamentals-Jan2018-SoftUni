using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, 
        string lastName, double salary, IList<IPrivate> privates) 
        : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public IList<IPrivate> Privates { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");
        foreach (var person in this.Privates)
        {
            sb.AppendLine($"  {person.ToString()}");
        }

        return sb.ToString().Trim();
    }
}

