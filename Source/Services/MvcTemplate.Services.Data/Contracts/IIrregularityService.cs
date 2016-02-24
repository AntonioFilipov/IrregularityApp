namespace MvcTemplate.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using MvcTemplate.Data.Models;

    public interface IIrregularityService
    {
        Irregularity GetByPosition(int position);

        Irregularity GetById(int id);

        int Add(Irregularity irregularity);

        void Edit(int id, string title, string description, string authorId, int categoryId, int positionId, int? imageId);

        void Delete(int id);

        IEnumerable<Irregularity> GetAll();

        IList<Irregularity> GetMostRecent(int count);

        IQueryable<Irregularity> GetByPageOrdered(int page, string orderBy, string search);

        int GetPagesSearch(string search);
    }
}
