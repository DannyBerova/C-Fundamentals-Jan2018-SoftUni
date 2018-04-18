namespace BashSoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public IDirectoryManager InputOutputManager
        {
            get => this.inputOutputManager;
            private set => this.inputOutputManager = value;
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            int depth = int.Parse(this.Data[1]);
            this.InputOutputManager.TraverseDirectory(depth);
        }
    }
}
