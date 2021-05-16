using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Model
{
    public class Comment
    {
        //评论类
        public virtual int Id { get; set; }
        public virtual int PostId { get; set; }//帖子编号
        public virtual int ReviewerId { get; set; }//评论者编号
        public virtual int ReviewedId { get; set; }//被评论者编号
        public virtual string Content { get; set; }//评论内容
        public virtual string CommentDate { get; set; }//评论时间
    }
}
