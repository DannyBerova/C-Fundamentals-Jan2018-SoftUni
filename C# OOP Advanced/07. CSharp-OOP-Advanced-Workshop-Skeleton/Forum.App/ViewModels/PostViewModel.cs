using System.Collections.Generic;
using System.Linq;
using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    class PostViewModel : ContentViewModel, IPostViewModel
    {
        public PostViewModel(string title, string author, string content,
            IEnumerable<IReplyViewModel> replies)
            : base(content)
        {
            this.Title = title;
            this.Author = author;
            this.Replies = replies.ToArray();
        }

        public string Title { get; }

        public string Author { get; }

        public IReplyViewModel[] Replies { get; }
    }
}
