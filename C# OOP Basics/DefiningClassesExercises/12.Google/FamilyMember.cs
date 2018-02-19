using System;

public class FamilyMember
{
    private string name;
    private string birthday;

    public FamilyMember(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public string Birthday
    {
        get => this.birthday;
        set => this.birthday = value;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }

}
