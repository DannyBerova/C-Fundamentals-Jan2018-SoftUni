namespace BashSoft.IO.Commands
{
    using Attributes;
    using Contracts;
    using Exceptions;


    [Alias("cmp")]
    public class CompareFilesCommand : Command
    {
        [Inject]
        private IContentComparer judge;

        public CompareFilesCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public IContentComparer Judge
        {
            get => this.judge;
            private set => this.judge = value;
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string userOutputPath = this.Data[1];
            string expectedOutputPath = this.Data[2];
            this.Judge.CompareContent(userOutputPath, expectedOutputPath);
        }
    }
}
