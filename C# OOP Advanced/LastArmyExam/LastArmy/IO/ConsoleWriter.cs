using System;

namespace Last_Army.IO
{
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        private readonly StringBuilder sb;

        public ConsoleWriter()
        {
            this.sb = new StringBuilder();
        }

        public string StoredMessage => this.sb.ToString();

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void StoreMessage(string message)
        {
            this.sb.AppendLine(message.Trim());
        }
    }
}