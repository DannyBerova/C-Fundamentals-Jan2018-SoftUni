using _07.InfernoInfinity.Contracts;
using System;

namespace _07.InfernoInfinity.Core
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
