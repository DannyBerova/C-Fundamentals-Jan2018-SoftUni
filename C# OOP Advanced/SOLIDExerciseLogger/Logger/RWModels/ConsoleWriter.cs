using _Logger.Interfaces;
using System;

namespace _Logger.RWModels
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Write(string msg)
        {
            Console.Write(msg);
        }
    }
}