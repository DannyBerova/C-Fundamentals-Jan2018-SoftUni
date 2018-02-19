public class Cymric : Cat
{
    public double furLength;

    public Cymric(string breed, string name, double furLength) 
        : base(breed, name)
    {
        this.furLength = furLength;
    }

    public double FurLength
    {
        get
        {
            return this.furLength;
        }
        set
        {
            this.furLength = value;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.FurLength:f2}";
    }
}