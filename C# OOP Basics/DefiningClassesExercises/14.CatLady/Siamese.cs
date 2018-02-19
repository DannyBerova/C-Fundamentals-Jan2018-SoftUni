public class Siamese : Cat
{
    private int earSize;

    public Siamese(string breed, string name, int earSize) 
        : base(breed, name)
    {
        this.EarSize = earSize;
    }

    public int EarSize
    {
        get
        {
            return this.earSize;
        }
        set
        {
            this.earSize = value;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.EarSize}";
    }
}