using System;

namespace _09.CustomListIterator
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
