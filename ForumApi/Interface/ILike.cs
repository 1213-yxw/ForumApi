using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Interface
{
    using ForumApi.Model;
    public interface ILike
    {
        int GetLikes(int postId,int commentId);
        bool AddLike(Like like);
        bool DeleteLike(int postId,int commentId);
    }
}
