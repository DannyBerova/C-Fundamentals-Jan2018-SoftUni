namespace _07.InfernoInfinity.Models.Weapons
{
    using _07.InfernoInfinity.Models.Gems;

    public class Knife : Weapon
    {
        public Knife(string weaponType, string rarity, string name)
            : base(weaponType, rarity, name)
        {
            this.MinDamageStat = 3;
            this.MaxDamageStat = 4;
            this.Sockets = new Gem[2];
            this.AddRarityBonus();
        }
    }
}
