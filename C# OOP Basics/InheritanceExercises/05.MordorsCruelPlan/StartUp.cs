
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.MordorsCruelPlan
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfFoods = new List<Food>();
            var foodInputArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < foodInputArgs.Length; i++)
            {
                var currentFood = FoodFactory.CreateFood(foodInputArgs[i]);
                listOfFoods.Add(currentFood);
            }

            var gandalfsHappiness = MoodFactory.GandalfsHappiness(listOfFoods);
            var mood = MoodFactory.CreateMood(gandalfsHappiness);

            Console.WriteLine(gandalfsHappiness);
            Console.WriteLine(mood);
        }
    }
}
