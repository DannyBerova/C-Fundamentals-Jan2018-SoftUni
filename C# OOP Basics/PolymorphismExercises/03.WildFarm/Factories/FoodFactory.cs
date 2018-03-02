public static class FoodFactory
{
    public static Food ProduceFood(string[] foodArgs)
    {
        Food food = null;

        var typeOfFood = foodArgs[0];
        var foodQuantity = double.Parse(foodArgs[1]);

        switch (typeOfFood)
        {
            case "Vegetable":
                food = new Vegetable(foodQuantity);
                break;
            case "Seeds":
                food = new Seeds(foodQuantity);
                break;
            case "Fruit":
                food = new Fruit(foodQuantity);
                break;
            case "Meat":
                food = new Meat(foodQuantity);
                break;
            default:
                break;
        }
        return food;
    }
}

