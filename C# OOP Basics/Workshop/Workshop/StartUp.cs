namespace Forum.App
{
    public class StartUp : ReadMe
    {
        public static void Main(string[] args)
        {
            ReadMe informationToRead = new StartUp();
            informationToRead.GetInformation();
            informationToRead.StartCountDown();
            Engine engine = new Engine();
            engine.Run();
        }
    }
}

