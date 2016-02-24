namespace MvcTemplate.Services.Data.Contracts
{
    using MvcTemplate.Data.Models;
    public interface IImageService
    {
        Image GetById(int id);

        int Add(Image image);
    }
}
