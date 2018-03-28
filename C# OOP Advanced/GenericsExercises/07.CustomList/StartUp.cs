using System;

namespace _07.CustomList
{
    class StartUp
    {
        public static void Main()
        {
            var interpreter = new CommandInterpreter();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                interpreter.ParseCommand(input);
            }
        }
    }
}
