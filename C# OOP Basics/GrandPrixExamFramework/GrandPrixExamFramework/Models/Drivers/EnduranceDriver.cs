public class EnduranceDriver : Driver
{
    private const double FuelConsumption = 1.5;

    public EnduranceDriver(string name, Car car)
        : base(name, car, FuelConsumption)
    {
    }
}
