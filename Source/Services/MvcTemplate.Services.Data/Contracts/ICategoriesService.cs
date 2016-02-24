namespace MvcTemplate.Services.Data.Contracts
{
    using System.Linq;
    using MvcTemplate.Data.Models;
    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category EnsureCategory(string name);
    }
}
