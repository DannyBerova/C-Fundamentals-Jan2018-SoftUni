using _Logger.Interfaces;
using System;

namespace _Logger.RWModels
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}