public class Person
{
    private string name;
    private int age;

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

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }
    //public string Name { get; set; }
    //public int Age { get; set; }

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int age)
        : this()
    {
        this.Age = age;
    }

    public Person(string name, int age)
        : this(age)
    {
        this.Name = name;
    }
}