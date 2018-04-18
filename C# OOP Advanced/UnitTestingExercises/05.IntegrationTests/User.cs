using System.Collections.Generic;

namespace _05.IntegrationTests
{
    public class User
    {
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>(new CategoryComparator());

        public User(string name)
        {
            this.Name = name;
        }
    }
}
