namespace BashSoft.IO.Commands
{
    using Exceptions;
    using SimpleJudge;

    public class TraverseFoldersCommand : Command
    {
        public TraverseFoldersCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
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
