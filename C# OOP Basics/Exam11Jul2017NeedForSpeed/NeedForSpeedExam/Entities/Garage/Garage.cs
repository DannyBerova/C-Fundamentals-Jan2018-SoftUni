using System.Collections.Generic;

public class Garage
{
    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public IDictionary<int, Car> ParkedCars { get; protected set; }
}

