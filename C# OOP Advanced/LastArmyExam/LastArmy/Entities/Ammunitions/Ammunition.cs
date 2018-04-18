public abstract class Ammunition : IAmmunition
{
    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = weight * 100;
    }

    public string Name { get; }

    public double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
