namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using MvcTemplate.Web.Infrastructure.Populators;
    using MvcTemplate.Web.ViewModels.Irregularity;
    using MvcTemplate.Services.Data.Contracts;


    public class HomeController : BaseController
    {
        private readonly IDropDownListPopulator populator;
        private readonly IIrregularityService irregularities;

        public HomeController(IDropDownListPopulator populator, IIrregularityService irregularities)
        {
            this.populator = populator;
            this.irregularities = irregularities;
        }

        public ActionResult Index()
        {
            var dbIrregularities = this.irregularities.GetAll();

            var model = new HomeViewModel
            {
                Add = new AddIrregularityViewModel
                {
                    Categories = this.populator.GetCategories()
                },
                View = new ViewIrregularityViewModel
                {
                    Irregularities = dbIrregularities.ToList()
                }
            };

            return View(model);
        }
        public ActionResult MostRecentIrregularities()
        {
            return PartialView("_MostRecentIrregularitiesPartial", new ViewIrregularityViewModel {Irregularities = this.irregularities.GetMostRecent(10)});
        }

        public ActionResult Error()
        {
            return this.View();
        }
    }
}
