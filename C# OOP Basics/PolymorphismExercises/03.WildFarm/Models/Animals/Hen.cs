public class Hen : Bird
{
    public const double IncreaseWeightPercentage = 0.35;

    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    public override void IncreaseWeight(Food food)
    {
        this.Weight += food.FoodQuantity * IncreaseWeightPercentage;
        this.FoodEaten += food.FoodQuantity;
    }


    public override string ProduceSound()
    {
        return "Cluck";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

