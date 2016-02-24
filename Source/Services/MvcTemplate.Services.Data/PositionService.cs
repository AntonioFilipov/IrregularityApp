namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data.Contracts;

    public class PositionService : IPositionService
    {
        private readonly IDbRepository<Position> positions;

        public PositionService(IDbRepository<Position> positions)
        {
            this.positions = positions;
        }

        public Position GetPositionByLatitudeAndLongitude(string latitude, string longitude)
        {
            return this.positions.All().FirstOrDefault(x => x.Latitude.Equals(latitude) && x.Longitude.Equals(longitude));
        }

        public void Post(Position position)
        {
            positions.Add(position);
            positions.Save();
        }
    }
}
