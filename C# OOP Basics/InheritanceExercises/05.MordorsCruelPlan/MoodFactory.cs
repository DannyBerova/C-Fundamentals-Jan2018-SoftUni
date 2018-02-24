using System.Collections.Generic;
using System.Linq;

namespace _05.MordorsCruelPlan
{
    public static class MoodFactory
    {
        public static int GandalfsHappiness(List<Food> foods)
        {
            var indexOfHappiness = foods.Sum(food => food.PointsOfHappiness);
            return indexOfHappiness;
        }

        public static Mood CreateMood(int gandalfsHappiness)
        {
            if (gandalfsHappiness < -5) return new Angry();
            else if (gandalfsHappiness <= 0) return new Sad();
            else if (gandalfsHappiness <= 15) return new Happy();
            else return new JavaScript();
        }
    }

}
