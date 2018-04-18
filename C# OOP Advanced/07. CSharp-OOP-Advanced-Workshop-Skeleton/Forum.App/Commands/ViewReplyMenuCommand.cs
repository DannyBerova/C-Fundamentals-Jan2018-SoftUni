using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class ViewReplyMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public ViewReplyMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int categoryId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            IIdHoldingMenu menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName);
            menu.SetId(categoryId);

            return menu;
        }
    }
}
