namespace MvcTemplate.Services.Data.Contracts
{
    public interface IRatingService
    {
        void Rate(int irregularityId, int points);

        int GetByIrregularityId(int id);
    }
}
