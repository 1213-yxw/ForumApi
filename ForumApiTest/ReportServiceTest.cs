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
    public class ReportServiceTest
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
        public List<Report> reportdata = new List<Report>
        {
            new Report{Id=1,PostId=1,ReportId=2,HarmfulContent="有害信息",ReportDescription="该文章含有有害信息"}
        };
        private async Task<ForumDbContext> GetSqlServerDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<ForumDbContext>()
                .UseInMemoryDatabase(new Guid().ToString())
                .Options;
            var sqlServerDbContext = new ForumDbContext(options);
            sqlServerDbContext.Posts.AddRange(postdata);
            sqlServerDbContext.Users.AddRange(userdata);
            sqlServerDbContext.Reports.AddRange(reportdata);
            await sqlServerDbContext.SaveChangesAsync();
            return sqlServerDbContext;
        }

        [Fact]
        public async void AddReport()
        {
            var content = await GetSqlServerDbContextAsync();
            var reportService = new ReportService(content);
            Report report = new Report()
            {
                Id=2,PostId=1,ReportId=3, HarmfulContent = "有害信息", ReportDescription = "该文章含有有害信息"
            };
            var result = reportService.AddReport(report);
            Assert.True(result);
        }

        [Fact]
        public async void DeleteReport()
        {
            var content = await GetSqlServerDbContextAsync();
            var reportService = new ReportService(content);
            var result = reportService.DeleteReport(1);
            Assert.True(result);
        }
    }
}
