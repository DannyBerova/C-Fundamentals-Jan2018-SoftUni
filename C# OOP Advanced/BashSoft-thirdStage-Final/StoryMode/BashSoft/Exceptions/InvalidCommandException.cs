namespace BashSoft.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        private const string InvalidCommandMessage = "The command {0} is invalid.";

        public InvalidCommandException(string input)
            : base(string.Format(InvalidCommandMessage, input))
        {
        }
    }
}
