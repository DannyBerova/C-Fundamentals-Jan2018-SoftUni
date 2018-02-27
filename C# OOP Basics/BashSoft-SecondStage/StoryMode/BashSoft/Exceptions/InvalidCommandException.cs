namespace BashSoft.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        public const string InvalidCommand = "The command '{0}' is invalid";

        public InvalidCommandException()
            : base(InvalidCommand)
        {
        }

        public InvalidCommandException(string message)
            : base(message)
        {
        }
    }
}
