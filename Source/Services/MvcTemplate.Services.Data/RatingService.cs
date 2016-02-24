namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using System.Linq;
    using MvcTemplate.Services.Data.Contracts;

    public class RatingService : IRatingService
    {
        private readonly IDbRepository<Rating> ratings;

        public RatingService(IDbRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public int GetByIrregularityId(int id)
        {
            return this.ratings.All().Where(v => v.IrregularityId == id).Sum(v => v.Points);
        }

       public void Rate(int irregularityId, int points)
        {
            var newRate = new Rating
            {
                IrregularityId = irregularityId,
                Points = points,
            };

            this.ratings.Add(newRate);
            this.ratings.Save();
        }
    }
}
