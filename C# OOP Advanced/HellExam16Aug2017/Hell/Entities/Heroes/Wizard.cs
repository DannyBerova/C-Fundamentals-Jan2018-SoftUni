public class Wizard : AbstractHero
{
    private const int strenghtValue = 25;
    private const int agilityValue = 25;
    private const int intelligenceValue = 100;
    private const int hitPointsValue = 100;
    private const int damageValue = 250;

    public Wizard(string name)
        : base(name, strenghtValue, agilityValue, intelligenceValue, hitPointsValue, damageValue)
    {
    }
}
