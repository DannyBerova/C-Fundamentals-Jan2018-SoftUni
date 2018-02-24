namespace _04.OnlineRadioDatabase
{
    public class InvalidSongNameException : InvalidSongException
    {
        private const string Message = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException()
            :base(Message)
        {
        }

        public InvalidSongNameException(string message) 
            : base(message)
        {
        }
    }
}