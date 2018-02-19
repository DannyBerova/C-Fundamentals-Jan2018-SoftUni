using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<FamilyMember> parents;
    private List<FamilyMember> children;
    private List<Pokemon> pokemons;

    public Person(string name)
    {
        this.Name = name;
        this.Parents = new List<FamilyMember>();
        this.Children = new List<FamilyMember>();
        this.Pokemons = new List<Pokemon>();
    }
    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public Company Company
    {
        get => this.company;
        set => this.company = value;
    }

    public Car Car
    {
        get => this.car;
        set => this.car = value;
    }
    public List<Pokemon> Pokemons
    {
        get => this.pokemons;
        set => this.pokemons = value;
    }
    public List<FamilyMember> Parents
    {
        get => this.parents;
        set => this.parents = value;
    }
    public List<FamilyMember> Children
    {
        get => this.children;
        set => this.children = value;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"{this.Name}");
        builder.AppendLine("Company:");

        if (this.Company != null)
        {
            builder.AppendLine(Company.ToString());
        }

        builder.AppendLine("Car:");
        if (this.Car != null)
        {
            builder.AppendLine(this.Car.ToString());
        }

        builder.AppendLine("Pokemon:");
        this.Pokemons.ForEach(p => builder.AppendLine(p.ToString()));

        builder.AppendLine("Parents:");
        this.Parents.ForEach(p => builder.AppendLine(p.ToString()));

        builder.AppendLine("Children:");
        this.Children.ForEach(ch => builder.AppendLine(ch.ToString()));

        return builder.ToString().Trim();
    }
}
