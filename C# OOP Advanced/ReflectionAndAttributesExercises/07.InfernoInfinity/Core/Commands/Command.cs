namespace _07.InfernoInfinity.Core.Commands
{
    using _07.InfernoInfinity.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
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
