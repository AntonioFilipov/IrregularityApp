namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data.Contracts;

    public class ImageService : IImageService
    {
        private IDbRepository<Image> images;

        public ImageService(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public Image GetById(int id)
        {
            return this.images.GetById(id);
        }

        public int Add(Image image)
        {
            this.images.Add(image);
            this.images.Save();

            return image.Id;
        }
    }
}
