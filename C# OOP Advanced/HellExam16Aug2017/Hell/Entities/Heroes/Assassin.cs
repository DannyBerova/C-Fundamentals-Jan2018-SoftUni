public class Assassin : AbstractHero
{
    private const int strenghtValue = 25;
    private const int agilityValue = 100;
    private const int intelligenceValue = 15;
    private const int hitPointsValue = 150;
    private const int damageValue = 300;

    public Assassin(string name)
        : base(name, strenghtValue, agilityValue, intelligenceValue, hitPointsValue, damageValue)
    {
    }
}

