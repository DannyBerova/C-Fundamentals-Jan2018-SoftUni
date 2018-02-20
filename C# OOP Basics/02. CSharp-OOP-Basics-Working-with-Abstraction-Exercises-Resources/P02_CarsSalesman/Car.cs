using System.Text;

class Car
{
    private const string offset = "  ";

    private string model;
    private Engine engine;
    private int weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = -1;
        this.Color = "n/a";
    }

    public Car(string model, Engine engine, int weight)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = "n/a";
    }

    public Car(string model, Engine engine, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = -1;
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }
    internal Engine Engine
    {
        get => engine;
        set => engine = value;
    }
    public int Weight
    {
        get => weight;
        set => weight = value;
    }
    public string Color
    {
        get => color;
        set => color = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}:\n", this.Model);
        sb.Append(this.Engine.ToString());
        sb.AppendFormat("{0}Weight: {1}\n", offset, this.Weight == -1 ? "n/a" : this.Weight.ToString());
        sb.AppendFormat("{0}Color: {1}", offset, this.Color);

        return sb.ToString();
    }
}