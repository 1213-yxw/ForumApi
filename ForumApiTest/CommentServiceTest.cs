using System;
using Xunit;

namespace ForumApiTest
{
    using ForumApi;
    using ForumApi.Model;
    using ForumApi.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class CommentServiceTest
    {
        public List<Post> postdata = new List<Post>
        {
            new Post{ Id=1,AuthorId=1, Title="夏天", Content="XXXXXX",PostDate="2021-03-04 12:00" }
        };
        public List<User> userdata = new List<User>
        {
            new User{Id=1, UserName="张三",Password="123",Avatar="images/profilepicture01.jpg" },
             new User{Id=2, UserName="李四",Password="123",Avatar="images/profilepicture02.jpg" },
              new User{Id=3, UserName="王五",Password="123",Avatar="images/profilepicture03.jpg" }
        };
        public List<Comment> commentdata = new List<Comment>
        {
            new Comment{Id=1,PostId=1,ReviewerId=2,ReviewedId=1,Content="YYYYYY",CommentDate="2021-03-04 13:00"},
            new Comment{Id=2,PostId=1,ReviewerId=3,ReviewedId=1,Content="XXXXXX",CommentDate="2021-03-04 13:05"}
        };
        public List<Like> likedata = new List<Like>
        {
            new Like{Id=1,PostId=1,CommentId=0,SupportId=2},
            new Like{Id=2,PostId=1,CommentId=1,SupportId=2}
        };
        private async Task<ForumDbContext> GetSqlServerDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<ForumDbContext>()
                .UseInMemoryDatabase(new Guid().ToString())
                .Options;
            var sqlServerDbContext = new ForumDbContext(options);
            sqlServerDbContext.Posts.AddRange(postdata);
            sqlServerDbContext.Users.AddRange(userdata);
            sqlServerDbContext.Comments.AddRange(commentdata);
            sqlServerDbContext.Likes.AddRange(likedata);
            await sqlServerDbContext.SaveChangesAsync();
            return sqlServerDbContext;
        }
    
    [Fact]
        public async void GetComments()
        {
            var content = await GetSqlServerDbContextAsync();
            var commentService = new CommentService(content);
            var result = commentService.GetComments(1);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async void AddComment()
        {
            var content = await GetSqlServerDbContextAsync();
            var commentService = new CommentService(content);
            Comment comment = new Comment()
            {
                Id=3,PostId=1,ReviewerId=3,ReviewedId=1,Content="WWWWWWW",CommentDate="2021-03-04 13:10"
            };

            var result = commentService.AddComment(comment);
            Assert.True(result);
        }

        [Fact]
        public async void GetUser()
        {
            var content = await GetSqlServerDbContextAsync();
            var commentService = new CommentService(content);
            var result = commentService.GetUser(1);
            Assert.NotNull(result);
        }
    }
}
