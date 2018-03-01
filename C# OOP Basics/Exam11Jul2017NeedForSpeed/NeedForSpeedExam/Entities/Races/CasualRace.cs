using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public List<Car> GetWiners()
    {
        var winers = this.Participants.Values
                           .OrderByDescending(c => c.GetOverallPerformance())
                           .Take(3)
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
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");

        var winers = GetWiners();
        var counter = 1;
        var pp = 0;
        var money = 0;
        foreach (var winer in winers)
        {
            pp = winer.GetOverallPerformance();

            if (counter == 1)
            {
                money = (this.PrizePool * 50) / 100;
            }
            else if (counter == 2)
            {
                money = (this.PrizePool * 30) / 100;
            }
            else if (counter == 3)
            {
                money = (this.PrizePool * 20) / 100;
            }

            sb.AppendLine($"{counter}. {winer.Brand} {winer.Model} {pp}PP - ${money}");
            counter++;
        }

        return sb.ToString().Trim();

    }


}
