using MvcTemplate.Data.Common;
using MvcTemplate.Data.Models;
using MvcTemplate.Services.Web;

namespace MvcTemplate.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using MvcTemplate.Data;

    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IDbRepository<Category> categories;
        private ICacheService cache;

        public DropDownListPopulator(IDbRepository<Category> categories, ICacheService cache)
        {
            this.categories = categories;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var cachedCategories = this.cache.Get<IEnumerable<SelectListItem>>("categories",
                () =>
                {
                    return this.categories
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                }, 60 * 60);

            return cachedCategories;
        }
    }
}