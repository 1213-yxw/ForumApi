using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    using ForumApi.Interface;
    using ForumApi.Model;
    public class LikeService : ILike
    {
        public ForumDbContext dbContext_;
        public LikeService(ForumDbContext db)
        {
            dbContext_ = db;
        }
        public bool AddLike(Like like)
        {
           var item = this.GetLike(like.PostId,like.CommentId,like.SupportId);
          if(item==null){
            dbContext_.Likes.Add(like);
            return dbContext_.SaveChanges()>0;
          }else{return false;}
        }

        public bool DeleteLike(int postId,int commentId,int supportId)
        {
            var like = (from l in dbContext_.Likes
                        where l.PostId == postId && l.CommentId == commentId && l.SupportId == supportId
                        select l).FirstOrDefault();
            dbContext_.Likes.Attach(like);
            dbContext_.Likes.Remove(like);
            return dbContext_.SaveChanges()>0;
        }

       public Like GetLike(int postId,int commentId,int supportId)
       {
             var like=(from l in dbContext_.Likes
                     where l.PostId==postId&&l.CommentId==commentId&&l.SupportId==supportId
                     select l).FirstOrDefault();
              return like;
        }

        public int GetLikes(int postId, int commentId)
        {
            int sum = 0;
            foreach (var like in dbContext_.Likes)
            {
                if (like.PostId == postId&&like.CommentId==commentId)
                {
                    sum += 1;
                }
            }
            return sum;
        }
    }
}
