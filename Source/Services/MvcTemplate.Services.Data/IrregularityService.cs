namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MvcTemplate.Common;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data.Contracts;
    using MvcTemplate.Services.Web;

    public class IrregularityService : IIrregularityService
    {
        private readonly IDbRepository<Irregularity> irregularities;
        private readonly IIdentifierProvider identifierProvider;

        public IrregularityService(IDbRepository<Irregularity> irregularities, IIdentifierProvider identifierProvider)
        {
            this.irregularities = irregularities;
            this.identifierProvider = identifierProvider;
        }
        public Irregularity GetByPosition(int position)
        {
            return irregularities.All().FirstOrDefault(i => i.PositionId == position);
        }

        public IQueryable<Irregularity> GetByPageOrdered(int page, string orderBy, string search)
        {
            var result = this.irregularities.All()
                .Where(x => x.Title.Contains(search) || x.Description.Contains(search));

            switch (orderBy)
            {
                case "votes":
                    result = result.OrderByDescending(x => x.Rating.Count);
                    break;
                case "date":
                    result = result.OrderBy(x => x.CreatedOn);
                    break;
            }

            return result
                .Skip((page - 1) * GlobalConstants.IdeasPageSize)
                .Take(GlobalConstants.IdeasPageSize);
        }

        public Irregularity GetById(int id)
        {
            return this.irregularities.GetById(id);
        }

        public int Add(Irregularity irregularity)
        {
            irregularities.Add(irregularity);
            irregularities.Save();

            return irregularity.Id;
        }

        public void Edit(int id, string title, string description, string authorId, int categoryId, int positionId, int? imageId)
        {
            var irregularityToBeDeleted = this.irregularities.GetById(id);
            irregularityToBeDeleted.Title = title;
            irregularityToBeDeleted.Description = description;
            irregularityToBeDeleted.AuthorId = authorId;
            irregularityToBeDeleted.CategoryId = categoryId;
            irregularityToBeDeleted.PositionId = positionId;

            if (imageId != null && imageId != 0)
            {
                irregularityToBeDeleted.ImageId = (int)imageId;
            }

            this.irregularities.Save();
        }

        public void Delete(int id)
        {
            var irregularityToBeDeleted = this.irregularities.GetById(id);
            this.irregularities.Delete(irregularityToBeDeleted);
            this.irregularities.Save();
        }

        public IEnumerable<Irregularity> GetAll()
        {
            return this.irregularities.All().OrderByDescending(i=>i.CreatedOn).ToList();
        }

        public IList<Irregularity> GetMostRecent(int count)
        {
            return this.irregularities.All().OrderByDescending(i => i.CreatedOn).Take(count).ToList();
        }

        public int GetPagesSearch(string search)
        {
            var ideas = this.irregularities.All()
                .Where(x => x.Title.Contains(search) || x.Description.Contains(search));

            return (int)Math.Ceiling(ideas.Count() / (decimal)GlobalConstants.IdeasPageSize);
        }
    }
}
