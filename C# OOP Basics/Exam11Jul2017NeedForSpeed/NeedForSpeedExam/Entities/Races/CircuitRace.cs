using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; private set; }

    public List<Car> GetWiners()
    {
        var winers = this.Participants.Values
                           .OrderByDescending(c => c.GetOverallPerformance())
                           .Take(4)
                           .ToList();

        return winers;
    }

    public override int GetPerformancePoints()
    {
        var winers = GetWiners();

        var performancePoints = winers.Sum(c => c.GetOverallPerformance());

        return performancePoints;
    }

    public override string ToString()
    {
        for (int i = 0; i < Laps; i++)
        {
            foreach (var car in this.Participants)
            {
                car.Value.Durability -= this.Length * this.Length;
            }
        }
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");

        var winers = GetWiners();
        var counter = 1;
        var pp = 0;
        var money = 0;
        foreach (var winer in winers)
        {
            pp = winer.GetOverallPerformance();

            if (counter == 1)
            {
                money = (this.PrizePool * 40) / 100;
            }
            else if (counter == 2)
            {
                money = (this.PrizePool * 30) / 100;
            }
            else if (counter == 3)
            {
                money = (this.PrizePool * 20) / 100;
            }
            else if (counter == 4)
            {
                money = (this.PrizePool * 10) / 100;
            }

            sb.AppendLine($"{counter}. {winer.Brand} {winer.Model} {pp}PP - ${money}");
            counter++;
        }

        return sb.ToString().Trim();

    }

}