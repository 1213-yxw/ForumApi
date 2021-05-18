using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    using ForumApi.Model;
    using ForumApi.Interface;
    public class PostService : IPost
    {
        public ForumDbContext dbContext_;
        public LikeService likeService_;
        public PostService(ForumDbContext db)
        {
            dbContext_ = db;
            likeService_ = new LikeService(db);
        }
        public PostDto GetPost(int id)
        {
            var postItem = (from p in dbContext_.Posts
                            where p.Id == id
                            select p
                        ).FirstOrDefault();
            var author = GetUser(postItem.AuthorId);
            PostDto postDto = new PostDto
            {
                Id = postItem.Id,
                AuthorId = postItem.AuthorId,
                AuthorName = author.UserName,
                AuthorAvatar = author.Avatar,
                PostDate = postItem.PostDate,
                Title = postItem.Title,
                Content = postItem.Content,
                Likes = likeService_.GetLikes(postItem.Id, 0)
            };
            return postDto;
        }
        public User GetUser(int id)
        {
            var user = (from u in dbContext_.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            return user;
        }
    }
}
