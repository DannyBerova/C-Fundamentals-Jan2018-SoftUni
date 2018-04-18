public class Medium : Mission
{
    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => "Capturing dangerous criminals";

    public override double EnduranceRequired => 50;

    public override double WearLevelDecrement => 50;
}