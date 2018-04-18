public class Easy : Mission
{
    public Easy(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => "Suppression of civil rebellion";

    public override double EnduranceRequired => 20;

    public override double WearLevelDecrement => 30;
}
