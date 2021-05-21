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

        public List<PostDto> GetPosts()
        {
            var posts = (from p in dbContext_.Posts
                         select p).ToList();
            Console.WriteLine(posts.Count);
            List<PostDto> result = new List<PostDto>();
            foreach (var p in posts)
            {
                    var author = GetUser(p.AuthorId);
                    PostDto postDto = new PostDto()
                    {
                        Id = p.Id,
                        AuthorId = p.AuthorId,
                        AuthorAvatar = author.Avatar,
                        AuthorName = author.UserName,
                        PostDate = p.PostDate,
                        Title = p.Title,
                        Content = p.Content,
                        Likes = likeService_.GetLikes(p.Id, 0)
                    };
                    result.Add(postDto);
                }
            
            return result;
            
        }

        public bool AddPost(Post post)
        {
            dbContext_.Posts.Add(post);
            return dbContext_.SaveChanges() > 0;
        }

        public bool DeletePost(int authorId)
        {
            var post = (from p in dbContext_.Posts
                        where p.AuthorId == authorId
                        select p).FirstOrDefault();
            dbContext_.Posts.Remove(post);
            return dbContext_.SaveChanges() > 0;
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
