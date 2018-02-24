namespace _04.OnlineRadioDatabase
{
    public class Artist
    {
        private string name;

        public Artist(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.name = value;
            }
        }
    }
}