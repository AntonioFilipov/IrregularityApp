namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Models;
    public interface ICommentService
    {
        IQueryable<Comment> GetAll();

        void Add(string content, int irregularityId, string authorId);

        IQueryable<Comment> GetByIrregularityId(int irregularityId, int page);

        int GetPagesByIrregularityId(int irregularityId);
    }
}
