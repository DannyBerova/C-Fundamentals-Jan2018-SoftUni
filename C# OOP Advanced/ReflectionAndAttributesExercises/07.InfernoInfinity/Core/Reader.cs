using _07.InfernoInfinity.Contracts;
using System;

namespace _07.InfernoInfinity.Core
{
    public class Reader : IReader
    {
        private IServiceProvider serviceProvider;

        public Reader(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
