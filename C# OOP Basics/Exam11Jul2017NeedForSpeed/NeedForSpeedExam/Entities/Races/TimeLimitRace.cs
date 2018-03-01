using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; private set; }

    public int TimePerformance
    {
        get => this.GetPerformancePoints();
        set { this.TimePerformance = GetPerformancePoints(); }
    }

    public override int GetPerformancePoints()
    {
        var car = this.Participants.FirstOrDefault().Value;

        return this.Length * ((car.Horsepower / 100) * car.Acceleration);
    }

    public string GetTypeOfMedal()
    {
        string medal = string.Empty;
        if (TimePerformance <= this.GoldTime)
        {
            medal = "Gold";
        }
        else if (TimePerformance <= GoldTime + 15)
        {
            medal = "Silver";
        }
        else if (TimePerformance > GoldTime + 15)
        {
            medal = "Bronze";
        }

        return medal;
    }

    public int GetMoneyWon()
    {
        var car = this.Participants.FirstOrDefault().Value;

        var moneyWon = 0;
        if (GetTypeOfMedal() == "Gold")
        {
            moneyWon = this.PrizePool;
        }
        else if (GetTypeOfMedal() == "Silver")
        {
            moneyWon = (this.PrizePool * 50) / 100;
        }
        else if (GetTypeOfMedal() == "Bronze")
        {
            moneyWon = (this.PrizePool * 30) / 100;
        }

        return moneyWon;

    }

    public override string ToString()
    {
        var car = this.Participants.FirstOrDefault().Value;

        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");
        sb.AppendLine($"{car.Brand} {car.Model} - {TimePerformance} s.");
        sb.AppendLine($"{GetTypeOfMedal()} Time, ${GetMoneyWon()}.");
        return sb.ToString();

    }

}