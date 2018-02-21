using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough pizzaDough;
    //private List<Topping> toppings;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name)
        : this()
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new Exception("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough PizzaDough
    {
        get { return this.pizzaDough; }
        set { this.pizzaDough = value; }
    }

    public List<Topping> Toppings { get; }

    public void Add(Topping topping)
    {
        if (this.Toppings.Count >= 10)
        {
            throw new Exception("Number of toppings should be in range [0..10].");
        }

        this.Toppings.Add(topping);
    }

    public double PizzaCalories()
    {
        double totalToppingCalories = this.Toppings.Select(c => c.ToppingCalories())
                                                   .Sum();

        return this.PizzaDough.DoughCalories() + totalToppingCalories;
    }
}

