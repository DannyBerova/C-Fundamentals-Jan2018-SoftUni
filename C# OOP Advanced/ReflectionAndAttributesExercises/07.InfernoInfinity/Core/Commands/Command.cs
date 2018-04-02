namespace _07.InfernoInfinity.Core.Commands
{
    using _07.InfernoInfinity.Contracts;
    using System;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private readonly IServiceProvider serviceProvider;

        public Command(IServiceProvider serviceProvider, string[] data)
        {
            this.serviceProvider = serviceProvider;
            this.Data = data;
        }

        protected string[] Data
        {
            get { return data; }
            private set { data = value; }
        }

        public abstract string Execute();
    }
}
