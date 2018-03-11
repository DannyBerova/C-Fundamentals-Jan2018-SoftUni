﻿namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Services;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public PostViewModel() { }

        public PostViewModel(Post post)
        {
            this.PostId = post.Id;
            this.Title = post.Title;
            this.Content = this.GetLines(post.Content);
            this.Author = UserService.GetUser(post.AuthorId).Username;
            this.Category = PostService.GetCategory(post.CategoryId).Name;
            this.Replies = PostService.GetPostReplies(post.Id);
        }

        private IList<string> GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            IList<string> lines = new List<string>();

            for (int index = 0; index < content.Length; index += LINE_LENGHT)
            {
                char[] row = contentChars.Skip(index).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }
    }
}
