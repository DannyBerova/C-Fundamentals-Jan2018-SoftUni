namespace _07.InfernoInfinity.Contracts
{
    public interface IRepository
    {
        void AddWeapon(IWeapon weapon);
        IWeapon GetWeapon(string weaponName);
    }
}