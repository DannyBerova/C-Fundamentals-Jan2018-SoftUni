﻿namespace Forum.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User(int id, string username, string password, ICollection<int> postIds)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PostIds = new List<int>(postIds);
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<int> PostIds { get; set; }
    }
}
