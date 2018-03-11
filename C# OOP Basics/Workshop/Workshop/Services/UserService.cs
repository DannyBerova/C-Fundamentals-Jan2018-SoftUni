namespace Forum.App.Services
{
    using System;
    using System.Linq;
    using Controllers;
    using Forum.Data;
    using Forum.Models;
    using static Forum.App.Controllers.SignUpController;
    using System.Collections.Generic;

    public static class UserService
    {
        public static bool TryLoginUser(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);

            return userExists;
        }

        internal static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string name)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Username == name);

            return user;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !String.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !String.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExists)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

                User user = new User(userId, username, password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;

        }
    }
}
