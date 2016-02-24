using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MvcTemplate.Data.Models;

namespace MvcTemplate.Services.Data
{
    public interface IIrregularityService
    {
        Irregularity GetByPosition(int position);

        Irregularity GetById(int id);

        int Add(Irregularity irregularity);

        void Edit(int id, string title, string description, string authorId, int categoryId, int positionId, int? imageId);

        void Delete(int id);

        IEnumerable<Irregularity> GetAll();

        IList<Irregularity> GetMostRecent(int count);
        IQueryable<Irregularity> GetLast(int count);

        IQueryable<Irregularity> GetByPageOrdered(int page, string orderBy, string search);

        int GetPagesSearch(string search);

        IQueryable<Irregularity> GetTopByRating(int count);
    }
}
