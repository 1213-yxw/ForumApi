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

        
        [HttpGet("getMenus")]
        public List<Menu> GetMenus()
        {
            return menu_.GetMenus();
        }

        [HttpGet("getPosts/{authorId:int}")]
        public List<PostDto> GetPosts([FromRoute] int authorId)
        {
            return post_.GetPosts(authorId);
        }

        [HttpGet("getPostsAll")]
        public List<PostDto> GetPostsAll()
        {
            return post_.GetPostsAll();
        }

        [HttpPost("addPost")]
        public bool AddPost([FromBody] Post post) { 
            
            return post_.AddPost(post);
        }

        [HttpGet("deletePost/{postId:int}")]
        public bool DeletePost([FromRoute] int postId)
        {
            return post_.DeletePost(postId);
        }
    }
}
