public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}