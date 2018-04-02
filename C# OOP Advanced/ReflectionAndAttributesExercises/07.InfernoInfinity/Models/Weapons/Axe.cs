namespace _07.InfernoInfinity.Models.Weapons
{
    using _07.InfernoInfinity.Models.Gems;

    public class Axe : Weapon
    {
        public Axe(string weaponType, string rarity, string name) 
            : base(weaponType, rarity, name)
        {
            this.MinDamageStat = 5;
            this.MaxDamageStat = 10;
            this.Sockets = new Gem[4];
            this.AddRarityBonus();
        }
    }
}
