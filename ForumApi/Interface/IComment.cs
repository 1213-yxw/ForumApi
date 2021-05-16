using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Interface
{
    using ForumApi.Model;
    public interface IComment
    {
        List<CommentDto> GetComments(int id);
        bool AddComment(Comment comment);
    }
}
