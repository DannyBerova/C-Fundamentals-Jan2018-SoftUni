using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string content) 
            : base(content)
        {
            this.Author = author;
            this.Content = this.GetLines(content); //toCheck
        }

        public string Author { get; }
        public string[] Content { get; }
    }
}
