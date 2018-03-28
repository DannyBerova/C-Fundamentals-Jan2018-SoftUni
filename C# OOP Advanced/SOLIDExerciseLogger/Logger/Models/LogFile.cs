namespace _Logger.Models
{
   // using System.Linq;
    using System.Text;

    public class LogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; set; }

        public void Write(string formattedMessage)
        {
            this.sb.AppendLine(formattedMessage);

            //var test = formattedMsg.ToCharArray().Where(c => char.IsLetter(c)).ToList();
            //var testSum = test.Sum(c => c);

            foreach (var character in formattedMessage)
            {
                if (char.IsLetter(character))
                {
                    Size += character;
                }
            }
        }
    }
}