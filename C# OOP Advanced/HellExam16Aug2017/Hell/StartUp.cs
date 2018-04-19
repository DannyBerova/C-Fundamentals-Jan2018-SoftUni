public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IManager heroManager = new HeroManager();

        Engine engine = new Engine(reader, writer, heroManager);
        engine.Run();
    }
}