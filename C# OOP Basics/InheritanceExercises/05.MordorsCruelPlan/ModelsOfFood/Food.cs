namespace _05.MordorsCruelPlan
{
    public abstract class Food
    {
        protected int pointsOfHappiness;

        public Food(int pointsOfHappiness)
        {
            this.PointsOfHappiness = pointsOfHappiness;
        }

        public int PointsOfHappiness
        {
            get => this.pointsOfHappiness;
            set => this.pointsOfHappiness = value;
        }
    }
}
