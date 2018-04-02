namespace _07.InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(string clarity) 
            : base(clarity)
        {
            this.StrengthBonus = 7;
            this.AgilityBonus = 2;
            this.VitalityBonus = 5;
            this.AddBonusFromClarity();
        }
    }
}
