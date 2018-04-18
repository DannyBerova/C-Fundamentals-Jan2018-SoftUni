using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IIdHoldingMenu menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName + "Menu");
            menu.SetId(postId);

            return menu;
        }
    }
}

