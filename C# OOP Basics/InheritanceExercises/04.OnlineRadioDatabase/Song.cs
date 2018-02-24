using System.Text.RegularExpressions;

namespace _04.OnlineRadioDatabase
{
    public class Song
    {
        private Artist artist;
        private string name;
        private string lenght;

        public Song(Artist artist, string name, string lenght)
        {
            this.Artist = artist;
            this.Name = name;
            this.Lenght = lenght;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.name = value;
            }
        }

        public Artist Artist
        {
            get { return this.artist; }
            private set { this.artist = value; }
        }

        public string Lenght
        {
            get { return this.lenght; }
            private set
            {
                string pattern = @"^\d+:\d+";
                Regex rgx = new Regex(pattern);
                if (!rgx.IsMatch(value))
                {
                    throw new InvalidSongLengthException();
                }

                var time = value.Split(':');
                var minutes = int.Parse(time[0]);
                var seconds = int.Parse(time[1]);

                if (minutes < 0 || minutes > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                if (seconds < 0 || seconds > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.lenght = value;
            }
        }
    }
}