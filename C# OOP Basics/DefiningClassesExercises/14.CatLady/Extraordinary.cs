public class Extraordinary : Cat
{
    private int decibels;

    public Extraordinary(string breed, string name, int decibels) 
        : base(breed, name)
    {
        this.Decibels = decibels;
    }

    public int Decibels
    {
        get
        {
            return this.decibels;
        }
        set
        {
            this.decibels = value;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.Decibels}";
    }
}