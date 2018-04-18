namespace _01.EventImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var name = Console.ReadLine();
            while (name != "End")
            {
                dispatcher.Name = name;

                name = Console.ReadLine();
            }
        }
    }
}
