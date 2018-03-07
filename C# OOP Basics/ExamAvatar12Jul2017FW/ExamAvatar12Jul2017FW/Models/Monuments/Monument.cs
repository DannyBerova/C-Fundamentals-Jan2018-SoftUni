public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }
    public abstract double GetAffinity();

    public override string ToString()
    {
        return $"Monument: {this.name}";
    }

}

