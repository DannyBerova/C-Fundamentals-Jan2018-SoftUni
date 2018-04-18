using System.Collections.Generic;

namespace _05.IntegrationTests
{
    public class CategoryComparator : IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Category obj)
        {
            return this.GetHashCode();
        }
    }
}
