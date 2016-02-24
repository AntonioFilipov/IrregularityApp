namespace MvcTemplate.Services.Data
{
    public interface IRatingService
    {
        void Rate(int irregularityId, int points);

        int GetByIrregularityId(int id);
    }
}
