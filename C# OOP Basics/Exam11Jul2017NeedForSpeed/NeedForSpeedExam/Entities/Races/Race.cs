using System.Collections.Generic;

public abstract class Race
{
    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }

    public int Length { get; private set; }
    public string Route { get; private set; }
    public int PrizePool { get; private set; }
    public Dictionary<int, Car> Participants { get; private set; }

    public abstract int GetPerformancePoints();
}

