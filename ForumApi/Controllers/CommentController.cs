using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Controllers
{
    using ForumApi.Model;
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public List<Post> posts = new List<Post>
        {
            new Post{Id=1,AuthorId=1,PostDate=DateTime.Parse("2021-03-04 12:32"),Title="<h3>XXXXXXXXXXX</h3>",Content="<p>VVVVVVVVVVVVV</p>" }
        };
        public List<Comment> comments = new List<Comment>
        {
            new Comment{Id=1,PostId=1,AuthorId=1,CommentatorId=2,CommentDate=DateTime.Parse("2021-03-04 13:05"),Content="OKKKK"},
            new Comment{Id=2,PostId=1,AuthorId=1,CommentatorId=3,CommentDate=DateTime.Parse("2021-03-04 13:15"),Content="okkkkk"},
            new Comment{Id=3,PostId=1,AuthorId=2,CommentatorId=3,CommentDate=DateTime.Parse("2021-03-04 13:33"),Content="YYYYYYY"}
        };
        public List<Like> likes = new List<Like>
        {
            new Like{Id=1,AuthorId=1,CommentId=0,PostId=1,SupportId=2},
        };
    }
}
