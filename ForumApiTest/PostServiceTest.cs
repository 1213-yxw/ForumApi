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
    public class PostServiceTest
    {
        public List<Post> postdata = new List<Post>
        {
            new Post{ Id=1,AuthorId=1, Title="夏天", Content="XXXXXX",PostDate="2021-03-04 12:00" },
            new Post{ Id=2,AuthorId=1, Title="春天", Content="XXXXXX",PostDate="2021-05-04 12:00" },
            new Post{ Id=3,AuthorId=2, Title="秋天", Content="XXXXXX",PostDate="2021-09-04 12:00" },
            new Post{ Id=4,AuthorId=3, Title="冬天", Content="XXXXXX",PostDate="2021-01-04 12:00" }
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
        public List<Menu> menudata = new List<Menu>
        {
            new Menu{Id=1,Url="/xxx/yyy",Text="菜单1"},
            new Menu{Id=2,Url="/xxx/zzz",Text="菜单2"}
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
            sqlServerDbContext.Menus.AddRange(menudata);
            await sqlServerDbContext.SaveChangesAsync();
            return sqlServerDbContext;
        }
        [Fact]
        public async void GetPost()
        {
            var context = await GetSqlServerDbContextAsync();
            var postService = new PostService(context);
            var result = postService.GetPost(1);
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetUser()
        {
            var context = await GetSqlServerDbContextAsync();
            var postService = new PostService(context);
            var result = postService.GetUser(3);
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetPosts()
        {
            var content = await GetSqlServerDbContextAsync();
            var postService = new PostService(content);
            var result = postService.GetPosts(1);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetPostsAll()
        {
            var content = await GetSqlServerDbContextAsync();
            var postService = new PostService(content);
            var result = postService.GetPostsAll();
            Assert.NotNull(result);
        }

        [Fact]
        public async void AddPost()
        {
            var content = await GetSqlServerDbContextAsync();
            var postService = new PostService(content);
            Post post = new Post()
            {
                Id = 5,
                AuthorId = 2,
                Title = "四季",
                Content = "春夏秋冬",
                PostDate = "2021-05-25 14:00"
            };
            var result = postService.AddPost(post);
            Assert.True(result);
        }

        [Fact]
        public async void DeletePost()
        {
            var content = await GetSqlServerDbContextAsync();
            var postService = new PostService(content);
            var result = postService.DeletePost(3);
            Assert.True(result);
        }

        [Fact]
        public async void GetMenus()
        {
            var content = await GetSqlServerDbContextAsync();
            var menuService = new MenuService(content);
            var result = menuService.GetMenus();
            Assert.NotEmpty(result);
        }
    }
}
