using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender newBender) => this.benders.Add(newBender);

    public void AddMonument(Monument newMonument) => this.monuments.Add(newMonument);

    public double GetTotalPower()
    {
        var monumentsIncreaseRatio = this.monuments.Sum(m => m.GetAffinity());
        var bendersSummedPower = this.benders.Sum(b => b.GetPower());
        var totalPower = bendersSummedPower + ((bendersSummedPower / 100) * monumentsIncreaseRatio);
        return totalPower;
    }

    public void ClearDefeatedArmy()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append("Benders:");
        if (this.benders.Count != 0)
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.benders.Select(b => $"###{b}")));
        }
        else
        {
            result.AppendLine(" None");
        }

        result.Append("Monuments:");
        if (this.monuments.Count != 0)
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.monuments.Select(m => $"###{m}")));
        }
        else
        {
            result.Append(" None");
        }

        return result.ToString();
    }
}

