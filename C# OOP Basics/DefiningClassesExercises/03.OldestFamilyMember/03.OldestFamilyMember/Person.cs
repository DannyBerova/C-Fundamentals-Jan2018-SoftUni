public class Person
{
    public string name;
    public int age;

    public string Name { get { return this.name; } set { this.name = value; } }
    public int Age { get { return this.age; } set { this.age = value; } }

    public Person()
    {
        Name = "No name";
        age = 1;
    }

    public Person(int age) : this()
    {
        Age = age;
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

