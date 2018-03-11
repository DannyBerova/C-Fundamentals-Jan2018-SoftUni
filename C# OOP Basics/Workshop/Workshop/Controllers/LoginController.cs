﻿namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Services;
    using UserInterface;
    using Views;

    public class LogInController : IController, IReadUserInfoController
    {
        private enum Command
        {
            ReadUsername,
            ReadPassword,
            LogIn,
            Back
        }

        public LogInController()
        {
            this.ResetLogin();
        }

        private string Password { get; set; }

        private bool Error { get; set; }

        public string Username { get; set; }

        private void ResetLogin()
        {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Login;
                case Command.LogIn:
                    bool loggedIn = UserService.TryLoginUser(this.Username, this.Password);
                    if (loggedIn)
                    {
                        return MenuState.SuccessfulLogIn;
                    }
                    this.Error = true;
                    return MenuState.Rerender;
                case Command.Back:
                    this.ResetLogin();
                    return MenuState.Back;
            }

            throw new System.InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }
    }
}
