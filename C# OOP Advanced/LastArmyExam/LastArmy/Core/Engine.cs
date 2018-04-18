using System;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IGameController gameController;
    private IMissionController missionController;
    private IArmy army;
    private IWareHouse wareHouse;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IAmmunitionFactory ammunitionFactory;

    public Engine(IReader reader, IWriter writer, IMissionController missionController, IGameController gameController, IArmy army, IWareHouse wareHouse
        , ISoldierFactory soldierFactory, IMissionFactory missionFactory, IAmmunitionFactory ammunitionFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.missionController = missionController;
        this.gameController = gameController;
        this.army = army;
        this.wareHouse = wareHouse;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.ammunitionFactory = ammunitionFactory;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();

        while (!input.Equals(OutputMessages.InputTerminateString))
        {
            try
            {
                this.gameController.ProcessCommand(input);
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }

            input = this.reader.ReadLine();
        }

        this.gameController.ProduceSummury();
        this.writer.WriteLine(this.writer.StoredMessage.Trim());
    }
}