namespace _04.OnlineRadioDatabase
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        private const string Message = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException()
            : base(Message)
        {
        }

        public InvalidSongSecondsException(string message)
            : base(message)
        {
        }
    }
}