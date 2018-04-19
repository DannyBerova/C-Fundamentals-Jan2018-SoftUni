public class Barbarian : AbstractHero
{
    private const int strenghtValue = 90;
    private const int agilityValue = 25;
    private const int intelligenceValue = 10;
    private const int hitPointsValue = 350;
    private const int damageValue = 150;

    public Barbarian(string name)
        : base(name, strenghtValue, agilityValue, intelligenceValue, hitPointsValue, damageValue)
    {
    }
}
