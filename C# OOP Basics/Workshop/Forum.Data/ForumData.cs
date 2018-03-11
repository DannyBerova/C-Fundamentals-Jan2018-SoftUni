namespace Forum.Data
{
    using Models;
    using System.Collections.Generic;

    public class ForumData
    {
        public ForumData()
        {
            this.Categories = DataMapper.LoadCategories();
            this.Users = DataMapper.LoadUsers();
            this.Posts = DataMapper.LoadPosts();
            this.Replies = DataMapper.LoadReplies();
        }

        public List<Category> Categories { get; set; }

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

        public List<Reply> Replies { get; set; }

        public void SaveChanges()
        {
            DataMapper.SaveUsers(this.Users);
            DataMapper.SavePosts(this.Posts);
            DataMapper.SaveReplies(this.Replies);
            DataMapper.SaveCategories(this.Categories);
        }
    }
}
