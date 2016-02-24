namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using MvcTemplate.Data.Models;
    using System.Collections.Generic;
    using MvcTemplate.Services.Data.Contracts;
    using MvcTemplate.Common;


    //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : Controller
    {
        private readonly IIrregularityService irregularities;

        public AdminController(IIrregularityService irregularities)
        {
            this.irregularities = irregularities;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Irregularities_Read([DataSourceRequest]DataSourceRequest request)
        {
            IEnumerable<Irregularity> irregularities = this.irregularities.GetAll();
            DataSourceResult result = irregularities.ToDataSourceResult(request, irregularity => new {
                Id = irregularity.Id,
                Title = irregularity.Title,
                Description = irregularity.Description,
                CreatedOn = irregularity.CreatedOn,
                ModifiedOn = irregularity.ModifiedOn,
                IsDeleted = irregularity.IsDeleted,
                DeletedOn = irregularity.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Irregularities_Create([DataSourceRequest]DataSourceRequest request, Irregularity irregularity)
        {
            if (ModelState.IsValid)
            {
                var entity = new Irregularity
                {
                    Title = irregularity.Title,
                    Description = irregularity.Description,
                    CreatedOn = irregularity.CreatedOn,
                    ModifiedOn = irregularity.ModifiedOn,
                    IsDeleted = irregularity.IsDeleted,
                    DeletedOn = irregularity.DeletedOn
                };

                this.irregularities.Add(entity);
                irregularity.Id = entity.Id;
            }

            return Json(new[] { irregularity }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Irregularities_Update([DataSourceRequest]DataSourceRequest request, Irregularity irregularity)
        {
            if (ModelState.IsValid)
            {
                this.irregularities.Edit(
                    irregularity.Id,
                    irregularity.Title,
                    irregularity.Description,
                    irregularity.AuthorId,
                    irregularity.CategoryId,
                    irregularity.PositionId,
                    irregularity.ImageId);
            }

            return Json(new[] { irregularity }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Irregularities_Destroy([DataSourceRequest]DataSourceRequest request, Irregularity irregularity)
        {
            this.irregularities.Delete(irregularity.Id);
            return Json(new[] { irregularity }.ToDataSourceResult(request, ModelState));
        }
    }
}
