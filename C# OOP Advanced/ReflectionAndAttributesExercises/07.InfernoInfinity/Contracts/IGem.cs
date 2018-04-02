namespace _07.InfernoInfinity.Contracts
{
    using _07.InfernoInfinity.Models.Enums;

    public interface IGem
    {
        Clarity Clarity { get; }
        int StrengthBonus { get; }
        int AgilityBonus { get; }
        int VitalityBonus { get; }

        void AddBonusFromClarity();
        int AddMinDamageBoost();
        int AddMaxDamageBoost();


    }
}
