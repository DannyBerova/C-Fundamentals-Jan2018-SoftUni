public interface IHero
{
    int Experience { get; }
    string Name { get; }
    IWeapon Weapon { get; }

    void Attack(ITarget target);
}