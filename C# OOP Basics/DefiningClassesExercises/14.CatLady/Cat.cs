public class Cat
{
    private string breed;
    private string name;

    public Cat(string breed, string name)
    {
        this.Breed = breed;
        this.Name = name;
    }

    public string Breed
    {
        get
        {
            return this.breed;
        }
        set
        {
            this.breed = value;
        }
    }
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name}";
    }
}