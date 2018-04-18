using System.Collections.Generic;

public class Army : IArmy
{
    private readonly List<ISoldier> soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers;

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (var soldier in this.Soldiers)
        {
            if (soldier.GetType().Name == soldierType)
            {
                soldier.Regenerate();
            }
        }
    }
}