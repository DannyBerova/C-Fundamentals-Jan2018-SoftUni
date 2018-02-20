using System.Text;

class Engine
{
    private const string offset = "  ";

    private string model;
    private int power;
    private int displacement;
    private string efficiency;

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = -1;
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power, int displacement)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = -1;
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }


    public string Model
    {
        get => model;
        set => model = value;
    }
    public int Power
    {
        get => power;
        set => power = value;
    }
    public int Displacement
    {
        get => displacement;
        set => displacement = value;
    }
    public string Efficiency
    {
        get => efficiency;
        set => efficiency = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}{1}:\n", offset, this.Model);
        sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.Power);
        sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
        sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.Efficiency);

        return sb.ToString();
    }
}
