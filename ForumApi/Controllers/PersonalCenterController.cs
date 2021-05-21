using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Controllers
{
    using ForumApi.Interface;
    using ForumApi.Model;
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalCenterController : ControllerBase
    {
        public IPost post_;
        public IMenu menu_;
        public PersonalCenterController(IPost post,IMenu menu)
        {
            post_ = post;
            menu_ = menu;
        }

        
        [HttpGet]
        public List<Menu> GetMenus()
        {
            return menu_.GetMenus();
        }
        //无法从数据库中取出所有属性
        [HttpGet("getPosts")]
        public List<PostDto> GetPosts()
        {
            return post_.GetPosts();
        }

        [HttpPost("addPost")]
        public bool AddPost([FromBody] Post post)
        {
            return post_.AddPost(post);
        }

        [HttpPost("deletePost/{authorId:int}")]
        public bool DeletePost([FromRoute] int authorId)
        {
            return post_.DeletePost(authorId);
        }
    }
}
