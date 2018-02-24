using System;

public class Person
{
    // 1. Add Fields
    private string name;
    private int age;

    // 2. Add Constructor
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    // 3. Add Properties
    public virtual string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    public virtual int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.age = value;
        }
    }

    // 4. Add Methods
    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}