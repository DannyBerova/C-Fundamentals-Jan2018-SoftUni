using System.Collections.Generic;

namespace _05.IntegrationTests
{
    public class Category
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>(new UserComparator());

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>(new CategoryComparator());

        public Category(string name)
        {
            this.Name = name;
        }
    }
}