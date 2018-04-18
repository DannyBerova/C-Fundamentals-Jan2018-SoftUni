﻿using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public PostCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            string postTitle = args[0];
            string postCategory = args[1];
            string postContent = args[2];

            int postId = this.postService.AddPost(userId, postTitle, postCategory, postContent);

            this.session.Back();
            ICommand viewPostCommand = this.commandFactory.CreateCommand("ViewPostMenu");
            return viewPostCommand.Execute(postId.ToString());
        }
    }
}
