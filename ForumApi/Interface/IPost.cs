using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Interface
{
    using ForumApi.Model;
    public interface IPost
    {
        PostDto GetPost(int id);
        abstract List<PostDto> GetPosts(int authorId);
        abstract List<PostDto> GetPostsAll();
        bool AddPost(Post post);
        bool DeletePost(int postId);
    }
}
