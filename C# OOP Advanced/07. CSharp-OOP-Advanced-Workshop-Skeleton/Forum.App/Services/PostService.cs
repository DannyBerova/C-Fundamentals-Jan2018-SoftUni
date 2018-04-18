using System;
using System.Collections.Generic;
using System.Linq;
using Forum.App.Contracts;
using Forum.App.ViewModels;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData
                .Categories.Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> posts = this.forumData.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories.Find(c => c.Id == categoryId)?.Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);
            IPostViewModel postView = new PostViewModel(post.Title,
                this.userService.GetUserName(post.AuthorId), post.Content, this.GetPostReplies(postId));

            return postView;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData.Replies.Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postCategory);
            bool emptyTitle = string.IsNullOrWhiteSpace(postTitle);
            bool emptyContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyCategory || emptyContent || emptyTitle)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            Category category = this.EnsureCategory(postCategory);

            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = this.userService.GetUserById(userId);

            Post post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

            forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            return post.Id;
        }

        private Category EnsureCategory(string postCategory)
        {
            Category category = this.forumData.Categories.FirstOrDefault(c => c.Name == postCategory);
            if (category == null)
            {
                int categoryId= forumData.Categories.Any() ? forumData.Categories.Last().Id + 1 : 1;
                category = new Category(categoryId, postCategory, new List<int>());
                forumData.Categories.Add(category);
                forumData.SaveChanges();
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            bool emptyContent = string.IsNullOrWhiteSpace(replyContents);

            if (emptyContent)
            {
                throw new ArgumentException("All fields must be filled!");
            }


            int replyId = forumData.Replies.Any() ? forumData.Replies.Last().Id + 1 : 1;

            var reply = new Reply(replyId, replyContents, userId, postId);

            var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);
            post.Replies.Add(replyId);

            forumData.Replies.Add(reply);
            forumData.SaveChanges();
        }
    }
}
