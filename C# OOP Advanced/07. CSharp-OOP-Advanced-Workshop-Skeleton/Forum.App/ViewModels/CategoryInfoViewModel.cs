using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    class CategoryInfoViewModel : ICategoryInfoViewModel
    {
        public CategoryInfoViewModel(int id, string name, int postCount)
        {
            this.Id = id;
            this.Name = name;
            this.PostCount = postCount;
        }
        public int Id { get; }

        public string Name { get; }

        public int PostCount { get; }
    }
}
