namespace _Logger
{
    using _Logger.Engine;
    using _Logger.Interfaces;
    using _Logger.Factories;
    using _Logger.RWModels;

    public class Startup
    {
        public static void Main()
        {
            var factoryAppender = new FactoryAppender();
            var factoryLayout = new FactoryLayout();

            IWriter consoleWriter = new ConsoleWriter();
            IReader consoleReader = new ConsoleReader();

            var controller = new Controller(factoryAppender, factoryLayout, consoleWriter, consoleReader);

            controller.Run();
        }
    }
}