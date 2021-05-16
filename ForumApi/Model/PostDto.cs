using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Model
{
    public class PostDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }//作者编号
        public string AuthorName { get; set; }//作者昵称
        public string AuthorAvatar { get; set; }//作者头像
        public string PostDate { get; set; }//发帖时间
        public string Title { get; set; }//文章标题
        public string Content { get; set; }//文章内容
        public int Likes { get; set; }//获赞
    }
}
