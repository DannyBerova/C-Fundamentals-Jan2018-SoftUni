public abstract class Miner
{
    private string id;

    protected Miner(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
    }

}

