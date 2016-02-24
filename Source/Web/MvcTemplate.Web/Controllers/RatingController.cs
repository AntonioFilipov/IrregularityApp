namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using MvcTemplate.Services.Data.Contracts;

    public class RatingController : BaseController
    {
        private readonly IRatingService ratings;

        public RatingController(IRatingService ratings)
        {
            this.ratings = ratings;
        }

        [HttpPost]
        public ActionResult Add(int irregularityId, string ratings)
        {
            var points = int.Parse(ratings);

            if (points != 1)
            {
                points = 1;
            }

            this.ratings.Rate(irregularityId, points);
            var newPoints = this.ratings.GetByIrregularityId(irregularityId);

            return this.Json(new { newPoints = newPoints });
        }
    }
}