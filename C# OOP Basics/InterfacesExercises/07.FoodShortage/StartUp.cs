using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var numOfPeople = int.Parse(Console.ReadLine());
        var listOfBuyers = new List<IBuyer>();

        for (int i = 0; i < numOfPeople; i++)
        {
            var buyerArgs = Console.ReadLine().Split();

            IBuyer currentBuyer;
            if (buyerArgs.Length == 3)
            {
                currentBuyer = new Rebel(buyerArgs[0], int.Parse(buyerArgs[1]), buyerArgs[2]);
            }
            else
            {
                currentBuyer = new Citizen(buyerArgs[0], int.Parse(buyerArgs[1]), buyerArgs[2], buyerArgs[3]);
            }

            listOfBuyers.Add(currentBuyer);
        }

        string buyerName;
        while ((buyerName = Console.ReadLine()) != "End")
        {
            foreach (var buyer in listOfBuyers.Where(b => b.Name == buyerName))
            {
                buyer.BuyFood();
            }
        }

        var totalAmountOfFood = listOfBuyers.Sum(b => b.Food);
        Console.WriteLine(totalAmountOfFood);
    }
}

