﻿using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class WriteCommand : ICommand
    {
        private ISession session;

        public WriteCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            ITextAreaMenu currentMenu = (ITextAreaMenu) this.session.CurrentMenu;
            currentMenu.TextArea.Write();

            return currentMenu;
        }
    }
}
