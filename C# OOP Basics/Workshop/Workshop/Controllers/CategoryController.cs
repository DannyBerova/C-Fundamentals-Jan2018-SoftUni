namespace Forum.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Models;
    using Services;
    using Views;

    public class CategoryController : IController, IPaginationController
    {
        private enum Command
        {
            Back = 0,
            ViewPost = 1, //Mistake in the description, I think it should be ViewCategory
            PreviousPage = 11,
            NextPage = 12
        }

        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public int CurrentPage { get; set; }

        private string[] PostTitles { get; set; }

        private int LastPage => this.PostTitles.Length / 11;

        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public int CategogryId { get; private set; }

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategory(0);
        }

        public void SetCategory(int categoryId)
        {
            this.CategogryId = categoryId;
        }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
            GetPosts();
        }

        private void GetPosts()
        {
            var allCategoryPosts = PostService.GetPostsByCategory(this.CategogryId);

            this.PostTitles = allCategoryPosts
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .Select(p => p.Title)
                .ToArray();
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewPost:
                    return MenuState.ViewPost;
                case Command.PreviousPage:
                    return MenuState.OpenCategory;
                case Command.NextPage:
                    return MenuState.OpenCategory;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            GetPosts();
            string categoryName = PostService.GetCategory(this.CategogryId).Name;
            return new CategoryView(categoryName, this.PostTitles, this.IsFirstPage, this.IsLastPage);
        }
    }
}
