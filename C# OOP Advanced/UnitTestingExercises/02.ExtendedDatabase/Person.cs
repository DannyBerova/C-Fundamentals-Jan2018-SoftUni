using System;

namespace _02.ExtendedDatabase
{
    public class Person : IPerson, IEquatable<IPerson>

    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id
        {
            get => id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }
                id = value;
            }
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(username));
                }
                username = value;
            }
        }

        public bool Equals(IPerson other)
        {
            bool result = this.Id == other.Id && this.Username == other.Username;
            return result;
        }
    }
}
