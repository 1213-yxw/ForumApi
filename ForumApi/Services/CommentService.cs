using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    using ForumApi.Interface;
    using ForumApi.Model;

    public class CommentService : IComment
    {
        public ForumDbContext dbContext_;
        public LikeService likeService_;
        public CommentService(ForumDbContext db)
        {
            dbContext_ = db;
            likeService_ = new LikeService(db);
        }
        public bool AddComment(Comment comment)
        {
            dbContext_.Comments.Add(comment);
            return dbContext_.SaveChanges() > 0;
        }

        public List<CommentDto> GetComments(int id)
        {
            var comments = (from c in dbContext_.Comments
                            where c.PostId == id
                            select c
                            ).ToList();
            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach (var comment in dbContext_.Comments)
            {
                //var reviewer = this.GetAuthor(comment.ReviewerId);
                CommentDto commentDto = new CommentDto
                {
                    Id = comment.Id,
                    PostId = comment.PostId,
                    ReviewedId = comment.ReviewedId,
                    //ReviewedName = this.GetAuthor(comment.ReviewedId).AuthorName,
                    ReviewerId = comment.ReviewerId,
                    //ReviewerName = reviewer.AuthorName,
                   // ReviewerAvatar = reviewer.Avatar,
                    CommentDate = comment.CommentDate,
                    Content = comment.Content,
                    Likes = likeService_.GetLikes(comment.PostId, comment.Id)
                };
                commentDtos.Add(commentDto);
            }
            return commentDtos;
        }
    }
}
