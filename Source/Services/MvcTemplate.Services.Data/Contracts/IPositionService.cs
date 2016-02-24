namespace MvcTemplate.Services.Data.Contracts
{
    using MvcTemplate.Data.Models;
    public interface IPositionService
    {
        Position GetPositionByLatitudeAndLongitude(string latitude, string longitude);

        void Post(Position position);
    }
}
