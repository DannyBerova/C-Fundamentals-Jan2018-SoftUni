using Last_Army.IO;

public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IArmy army = new Army();

        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IMissionFactory missionFactory = new MissionFactory();

        IWareHouse wareHouse = new WareHouse(ammunitionFactory);
        IMissionController missionController = new MissionController(army, wareHouse);
        IGameController gameController = new GameController(missionController, soldierFactory, missionFactory,
            writer, wareHouse, army);

        var engine = new Engine(reader, writer, missionController, gameController, army, wareHouse, soldierFactory,
            missionFactory, ammunitionFactory);
        engine.Run();
    }
}