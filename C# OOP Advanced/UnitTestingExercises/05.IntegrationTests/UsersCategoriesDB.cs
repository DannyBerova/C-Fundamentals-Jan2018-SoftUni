using System.Collections.Generic;
using System.Linq;

namespace _05.IntegrationTests
{
    public class UsersCategoriesDB
    {
        private ICollection<Category> categories;
        private ICollection<User> users;

        public UsersCategoriesDB()
        {
            this.categories = new List<Category>();
            this.users = new List<User>();
        }

        public ICollection<Category> Categories => this.categories;

        public ICollection<User> Users => this.users;

        public void AddUsers(params User[] users)
        {
            foreach (var user in users)
            {
                this.users.Add(user);
            }
        }

        public void AddCategories(params Category[] categories)
        {
            foreach (var category in categories)
            {
                this.categories.Add(category);
            }
        }

        public void RemoveCategories(params string[] categories)
        {
            foreach (var category in categories)
            {
                var categoryToRemove = this.categories.SingleOrDefault(x => x.Name == category);

                if (categoryToRemove.Categories.Any())
                {
                    var categoryUsers = categoryToRemove.Users;

                    foreach (var categoryUser in categoryUsers)
                    {
                        categoryUser.Categories.Remove(categoryToRemove);
                    }

                    var childCategory = this.categories.First(c => categoryToRemove.Name == c.Name).Categories.First();

                    foreach (var categoryUser in categoryUsers)
                    {
                        this.categories.FirstOrDefault(c => c.Name == childCategory.Name).Users.Add(categoryUser);
                    }
                }

                var possibleParentCategory = this.categories
                    .FirstOrDefault(c => c.Categories.Any(x => x.Name == categoryToRemove.Name));

                possibleParentCategory?.Categories.Remove(categoryToRemove);

                this.categories.Remove(categoryToRemove);
            }
        }

        public void AssignChildCategory(string childCategoryName, string categoryName)
        {
            var parentCategory = this.categories.SingleOrDefault(x => x.Name == categoryName);
            var childCategory = this.categories.SingleOrDefault(x => x.Name == childCategoryName);

            var possibleParentCategory = this.categories
                .FirstOrDefault(c => c.Categories.Any(x => x.Name == childCategoryName));

            possibleParentCategory?.Categories.Remove(childCategory);

            var newCategory = new Category(childCategoryName)
            {
                Users = new HashSet<User>(childCategory.Users, new UserComparator())
            };

            parentCategory.Categories.Add(newCategory);
        }

        public void AssignUserToCategory(string userName, string categoryName)
        {
            var user = this.users.SingleOrDefault(u => u.Name == userName);
            var category = this.categories.SingleOrDefault(x => x.Name == categoryName);

            category.Users.Add(user);
            user.Categories.Add(category);
        }
    }
}
