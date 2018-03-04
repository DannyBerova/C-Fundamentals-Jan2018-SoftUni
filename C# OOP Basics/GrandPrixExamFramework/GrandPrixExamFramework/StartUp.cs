public class StartUp
{
    public static void Main()
    {
        var raceTower = new RaceTower();
        var engine = new Engine(raceTower);
        engine.Start();
    }
}

