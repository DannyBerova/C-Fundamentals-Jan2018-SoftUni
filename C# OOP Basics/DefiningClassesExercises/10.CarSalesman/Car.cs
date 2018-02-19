using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = "n/a";
        this.Color = "n/a";
    }

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public Engine Engine
    {
        get => this.engine;
        set => this.engine = value;
    }

    public string Weight
    {
        get => this.weight;
        set => this.weight = value;
    }

    public string Color
    {
        get => this.color;
        set => this.color = value;
    }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .AppendLine($"{this.Model}:")
            .AppendLine($"  {this.Engine.Model}:")
            .AppendLine($"    Power: {this.Engine.Power}")
            .AppendLine($"    Displacement: {this.Engine.Displacement}")
            .AppendLine($"    Efficiency: {this.Engine.Efficiency}")
            .AppendLine($"  Weight: {this.Weight}")
            .AppendLine($"  Color: {this.Color}");

        return builder.ToString();
    }
}
