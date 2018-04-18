using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class BackCommand : ICommand
    {
        private ISession session;

        public BackCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu menu = this.session.Back();
            return menu;
        }
    }
}
