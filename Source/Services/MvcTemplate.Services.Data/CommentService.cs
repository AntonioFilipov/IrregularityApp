namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using MvcTemplate.Common;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data.Contracts;
    
    public class CommentService : ICommentService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Add(string content, int irregularityId, string authorId)
        {
            var newComment = new Comment
            {
                Content = content,
                IrregularityId = irregularityId,
                AuthorId = authorId
            };

            this.comments.Add(newComment);
            this.comments.Save();
        }

        public void Delete(int id)
        {
            var commentToDelete = this.comments.GetById(id);
            this.comments.HardDelete(commentToDelete);
            this.comments.Save();
        }

        public void Edit(int id, string content)
        {
            var commentToBeEdited = this.comments.GetById(id);

            commentToBeEdited.Content = content;

            this.comments.Save();
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All();
        }

        public IQueryable<Comment> GetByIrregularityId(int irregularityId, int page)
        {
            return this.comments.All()
                .OrderBy(c => c.CreatedOn)
                .Where(c => c.IrregularityId == irregularityId)
                .Skip((page - 1) * GlobalConstants.CommentsPageSize)
                .Take(GlobalConstants.CommentsPageSize);
        }

        public int GetPagesByIrregularityId(int irregularityId)
        {
            var comments = this.comments.All().Where(c => c.IrregularityId == irregularityId);

            return (int)Math.Ceiling(comments.Count() / (decimal)GlobalConstants.CommentsPageSize);
        }
    }
}
