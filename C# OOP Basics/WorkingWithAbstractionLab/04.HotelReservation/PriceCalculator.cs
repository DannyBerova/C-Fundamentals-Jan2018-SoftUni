using System;

public class PriceCalculator
{
    private decimal pricePerNight;
    private int nights;
    private Seasons season;
    private DiscountTypes discount;

    public PriceCalculator(string command)
    {
        var splitCommand = command.Split();
        pricePerNight = decimal.Parse(splitCommand[0]);
        nights = int.Parse(splitCommand[1]);
        season = Enum.Parse<Seasons>(splitCommand[2]);
        discount = DiscountTypes.None;
        if (splitCommand.Length > 3)
        {
            discount = Enum.Parse<DiscountTypes>(splitCommand[3]);
        }
    }
    public string CalculatePrice()
    {
        var tempTotal = pricePerNight * nights * (int)season;
        var discountPercentage = ((decimal)100 - (int)discount) / 100;
        var totalPrice = tempTotal * discountPercentage;
        return totalPrice.ToString("F2");
    }
}
