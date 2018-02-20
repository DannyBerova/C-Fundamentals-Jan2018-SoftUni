public class Unit
{
    public Unit(string name, long amount)
    {
        this.Name = name;
        this.Amount = amount;
    }
    public string Name { get; set; }
    public long Amount { get; set; }

    public override string ToString()
    {
        return $"##{this.Name} - {this.Amount}";
    }
}