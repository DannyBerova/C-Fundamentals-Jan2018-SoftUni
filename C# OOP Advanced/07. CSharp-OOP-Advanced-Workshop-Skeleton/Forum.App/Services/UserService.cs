using System;
using System.Linq;
using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }
        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                throw new ArgumentException("Username and Password must be longer than 3 symbols!");
            }

            bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Username taken!");
            }

            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password);
            forumData.Users.Add(user);
            forumData.SaveChanges();
            this.TryLogInUser(username, password);

            return true;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            User user = this.forumData.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return false;
            }

            session.Reset();
            session.LogIn(user);

            return true;
        }

        public string GetUserName(int userId)
        {
            var user = this.forumData.Users.Find(u => u.Id == userId);
            return user.Username;
        }

        public User GetUserById(int userId)
        {
            var user = this.forumData.Users.Find(u => u.Id == userId);
            return user;
        }
    }
}
