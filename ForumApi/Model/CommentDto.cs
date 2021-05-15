using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Model
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }//帖子编号
        public int ReviewerId { get; set; }//评论者编号
        public string ReviewerName { get; set; }//评论者昵称
        public string ReviewerAvatar { get; set; }//评论者头像
        public int ReviewedId { get; set; }//被评论者编号
        public string ReviewedName { get; set; }//被评论者昵称
        public string Content { get; set; }//评论内容
        public string CommentDate { get; set; }//评论时间
        public int Likes { get; set; }//获赞
    }
}
