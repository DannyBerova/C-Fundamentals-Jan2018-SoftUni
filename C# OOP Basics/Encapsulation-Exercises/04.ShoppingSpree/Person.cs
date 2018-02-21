using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            else
            {
                this.money = value;
            }
        }
    }
    public List<Product> BagOfProducts
    {
        get
        {
            return this.bagOfProducts;
        }
        set
        {
            this.bagOfProducts = value;
        }
    }

    public void Print()
    {

        if (this.BagOfProducts.Count != 0)
        {
            Console.WriteLine($"{this.Name} - {string.Join(", ", bagOfProducts)}");
        }
        else
        {
            Console.WriteLine($"{this.Name} - Nothing bought");
        }

    }
}

