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
   public  class UserServiceTest
    {
        public List<User> userdata = new List<User>
        {
            new User{Id=1, UserName="张三",Password="123",Avatar="images/profilepicture01.jpg" },
             new User{Id=2, UserName="李四",Password="123",Avatar="images/profilepicture02.jpg" },
              new User{Id=3, UserName="王五",Password="123",Avatar="images/profilepicture03.jpg" }
        };
        private async Task<ForumDbContext> GetSqlServerDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<ForumDbContext>()
                .UseInMemoryDatabase(new Guid().ToString())
                .Options;
            var sqlServerDbContext = new ForumDbContext(options);
            sqlServerDbContext.Users.AddRange(userdata);
            await sqlServerDbContext.SaveChangesAsync();
            return sqlServerDbContext;
        }

        [Fact]
        public async void Login()
        {
            var content = await GetSqlServerDbContextAsync();
            var service = new UserService(content);
            var result = service.Login("张三", "123");
            Assert.True(result);
        }
        [Fact]
        public async void Register()
        {
            var content = await GetSqlServerDbContextAsync();
            var service = new UserService(content);
            User user = new User()
            {
                UserName = "张三",
                Password = "123"
            };
            var result = service.Register(user);
            Assert.False(result);
        }
    }
}
