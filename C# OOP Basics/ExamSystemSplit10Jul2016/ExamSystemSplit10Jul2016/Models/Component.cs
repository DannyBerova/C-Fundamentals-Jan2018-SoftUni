public abstract class Component
{
    private string name;

    protected Component(string name)
    {
        this.Name = name;
    }
    public abstract string Type { get; }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

}

