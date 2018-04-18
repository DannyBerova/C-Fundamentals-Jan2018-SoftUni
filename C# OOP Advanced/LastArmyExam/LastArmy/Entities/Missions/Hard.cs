public class Hard : Mission
{
    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    { }

    public override string Name => "Disposal of terrorists";
    public override double EnduranceRequired => 80;
    public override double WearLevelDecrement => 70;
}
