public abstract class Food
    {
    public Food(double foodQuantity)
    {
        this.FoodQuantity = foodQuantity;
    }
    public double FoodQuantity { get; protected set; }
    }

