using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class CategoriesMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public CategoriesMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);
            return menu;
        }
    }
}
