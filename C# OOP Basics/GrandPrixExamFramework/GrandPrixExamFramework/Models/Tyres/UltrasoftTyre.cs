using System;

public class UltrasoftTyre : Tyre
{
    private const string NameOfUltrasoftTyre = "Ultrasoft";
    private double degradation;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    public override string Name => NameOfUltrasoftTyre;

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        var sum = this.Hardness + this.Grip;
        this.Degradation -= sum;
    }
}
