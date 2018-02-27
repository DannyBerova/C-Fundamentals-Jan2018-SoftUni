public class Citizen : IBuyer
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
        this.Food = 0;
    }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public string Id { get; private set; }

    public string Birthdate { get; private set; }

    public int Food { get; private set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

