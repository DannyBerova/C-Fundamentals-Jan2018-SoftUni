using _07.InfernoInfinity.Contracts;
using System;

namespace _07.InfernoInfinity.Core
{
    public class Writer : IWriter
    {
        public void WriteLine(string result)
        {
            Console.WriteLine(result);
        }
    }
}
