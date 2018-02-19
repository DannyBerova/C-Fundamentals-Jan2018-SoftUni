public class Engine
{
    private string model;
    private double power;
    private string displacement;
    private string efficiency;

    public Engine(string model, double power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public double Power
    {
        get => this.power;
        set => this.power = value;
    }

    public string Displacement
    {
        get => this.displacement;
        set => this.displacement = value;
    }

    public string Efficiency
    {
        get => this.efficiency;
        set => this.efficiency = value;
    }
}