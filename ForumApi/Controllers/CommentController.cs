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
    using ForumApi.Interface;
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public IPost post_;
        public IComment comment_;
        public ILike like_;
        public IReport report_;
        public CommentController(IPost post,IComment comment,ILike like,IReport report)
        {
            post_ = post;
            comment_ = comment;
            like_ = like;
            report_ = report;
        }
    
        [HttpPost("addComment")]
        public bool AddComment([FromBody] Comment comment)
        {
            return comment_.AddComment(comment);
        }

        [HttpPost("addReport")]
        public bool AddReport([FromBody] Report report)
        {
            return report_.AddReport(report);
        }

        [HttpGet("getPost/{nid:int}")]
        public PostDto GetPost([FromRoute] int nid)
        {
            return post_.GetPost(nid);
        }

        [HttpGet("getComments/{nid:int}")]
        public List<CommentDto> GetComments([FromRoute] int nid)
        {
            return comment_.GetComments(nid);
        }

        [HttpGet]
        [Route("~/api/[controller]/getLike/{postId:int}/{commentId:int}/{supportId:int}")]
        public bool GetLike([FromRoute] int postId,[FromRoute] int commentId,[FromRoute]int supportId)
        {
            return like_.GetLike(postId,commentId,supportId);
        }

        [HttpPost("addLike")]
        public bool AddLike([FromBody] Like like)
        {
            return like_.AddLike(like);
        }
        [HttpGet("deleteLike/{postId:int}/{commentId:int}/{supportId:int}")]
        public bool DeleteLike([FromRoute] int postId,[FromRoute]int commentId,[FromRoute]int supportId)
        {
            return like_.DeleteLike(postId,commentId,supportId);
        }
    }
}
