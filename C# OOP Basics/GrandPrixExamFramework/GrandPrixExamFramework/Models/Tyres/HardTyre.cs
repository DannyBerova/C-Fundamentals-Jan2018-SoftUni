public class HardTyre : Tyre
{
    private const string NameOfHardTyre = "Hard";

    public HardTyre(double hardness) 
        : base(hardness)
    {
    }

    public override string Name => NameOfHardTyre;
}
