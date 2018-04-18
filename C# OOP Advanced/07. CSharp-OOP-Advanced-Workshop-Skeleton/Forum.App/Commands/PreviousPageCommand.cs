using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class PreviousPageCommand : ICommand
    {
        private ISession session;

        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu currentMenu = this.session.CurrentMenu;
            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage(false); //ToCheckImplementation
            }

            return currentMenu;
        }
    }
}
