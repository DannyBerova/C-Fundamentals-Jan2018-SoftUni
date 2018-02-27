public class Ferrari : ICar
{
    public Ferrari(string driverName)
    {
        this.Driver = driverName;
        this.Model = "488-Spider";
    }
    public string Model { get; private set; }

    public string Driver { get; private set; }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.GasPedal()}/{this.Driver}";
    }
}

