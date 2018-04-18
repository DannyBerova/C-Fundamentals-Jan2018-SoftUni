using System;
using Forum.App.Contracts;

namespace Forum.App.Commands 
{
    class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory; //toCheck

        public SubmitCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string replyContent = args[0];
            int postId = int.Parse(args[1]);

            int userId = this.session.UserId;

            if (string.IsNullOrWhiteSpace(replyContent))
            {
                throw new ArgumentException("Cannot add an empty reply!");
            }

            this.postService.AddReplyToPost(postId, replyContent, userId);

            ICommand viewReplyCommand = this.commandFactory.CreateCommand("ViewReplyMenu"); //doIneedThat
            return this.session.Back();
        }
    }
}

