namespace _07.InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon Create(string weaponType, string rarity, string name);
    }
}
