namespace _07.InfernoInfinity.Contracts
{
    using _07.InfernoInfinity.Models.Enums;

    public interface IWeapon
    {
        string NameOfWeapon { get; }
        WeaponType WeaponType { get; }
        int MinDamageStat { get; }
        int MaxDamageStat { get; }
        IGem[] Sockets { get; }
        Rarity Rarity { get; }
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }

        void AddGem(int index, IGem gem);
        void RemoveGem(int index);
        void AddRarityBonus();
        //string ToString();


    }
}
