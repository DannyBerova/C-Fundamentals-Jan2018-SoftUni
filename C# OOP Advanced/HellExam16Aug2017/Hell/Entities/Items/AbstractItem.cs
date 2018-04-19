using System.Text;

public abstract class AbstractItem : IItem
{
    private string name;
    private int strengthBonus;
    private int agilityBonus;
    private int intelligenceBonus;
    private int hitPointsBonus;
    private int damageBonus;

    protected AbstractItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        this.Name = name;
        this.strengthBonus = strengthBonus;
        this.agilityBonus = agilityBonus;
        this.intelligenceBonus = intelligenceBonus;
        this.hitPointsBonus = hitPointsBonus;
        this.damageBonus = damageBonus;
    }

    public string Name
    {
        get => name;
        private set => name = value;
    }

    public int StrengthBonus
    {
        get => strengthBonus;
        private set => strengthBonus = value;
    }

    public int AgilityBonus
    {
        get => agilityBonus;
        private set => agilityBonus = value;
    }

    public int IntelligenceBonus
    {
        get => intelligenceBonus;
        private set => intelligenceBonus = value;
    }

    public int HitPointsBonus
    {
        get => hitPointsBonus;
        private set => hitPointsBonus = value;
    }

    public int DamageBonus
    {
        get => damageBonus;
        private set => damageBonus = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"###Item: {this.Name}");
        sb.AppendLine($"###+{this.StrengthBonus} Strength");
        sb.AppendLine($"###+{this.AgilityBonus} Agility");
        sb.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
        sb.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        sb.AppendLine($"###+{this.DamageBonus} Damage");

        return sb.ToString().Trim();
    }
}
