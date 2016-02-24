namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Populators;
    using MvcTemplate.Web.ViewModels.Irregularity;
    using System.IO;
    using System.Linq;
    using System.Web;
    using MvcTemplate.Services.Data.Contracts;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Comments;
    using MvcTemplate.Web.ViewModels.Home;
    using MvcTemplate.Web.ViewModels.Rating;

    public class IrregularityController : BaseController
    {
        private readonly IIrregularityService irregularities;
        private readonly IDropDownListPopulator populator;
        private readonly IPositionService positions;
        private readonly IImageService images;
        private readonly ICommentService comments;
        private readonly IRatingService ratings;


        public IrregularityController(
            IIrregularityService irregularities,
            IDropDownListPopulator populator,
            IPositionService positions,
            IImageService images,
            ICommentService comments,
            IRatingService ratings)
        {
            this.irregularities = irregularities;
            this.populator = populator;
            this.positions = positions;
            this.images = images;
            this.comments = comments;
            this.ratings = ratings;
        }

        [HttpGet]
        public ActionResult Add()
        {
            var addTicketViewModel = new AddIrregularityViewModel
            {
                Categories = this.populator.GetCategories()
            };

            return View(addTicketViewModel);
        }

        [HttpPost]
        public ActionResult Add(AddIrregularityViewModel irregularity)
        {
            if (irregularity != null && ModelState.IsValid)
            {
                string latitude = irregularity.Latitude;
                string longitude = irregularity.Longitude;

                var dbPosition = positions.GetPositionByLatitudeAndLongitude(latitude, longitude);
                if (dbPosition == null)
                {
                    var position = new Position {Latitude = latitude, Longitude = longitude};
                    positions.Post(position);
                }

                dbPosition = positions.GetPositionByLatitudeAndLongitude(latitude, longitude);

                var dbIrregularity = new Irregularity
                {
                    Title = irregularity.Title,
                    Description = irregularity.Description,
                    CategoryId = irregularity.CategoryId,
                    PositionId = dbPosition.Id
                };

                if (irregularity.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        irregularity.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        dbIrregularity.Image = new Image
                        {
                            Content = content,
                            FileExtension = irregularity.UploadedImage.FileName.Split(new[] { '.' }).Last()
                        };
                    }
                }

                int dbIrregularityId = irregularities.Add(dbIrregularity);
                ratings.Rate(dbIrregularityId, 0);
            }
            else
            {
                throw new InvalidOperationException();
            }

            return Redirect("/");
        }

        public ActionResult Image(int id)
        {
            var image = this.images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }

        public ActionResult All(int page = 1, string orderBy = "votes", string search = "")
        {
            var viewModel = new IrregularityAllViewModel();

            viewModel.Irregularities = this.irregularities.GetByPageOrdered(page, orderBy, search).To<IrregularityViewModel>().ToList();
            viewModel.PagesCount = this.irregularities.GetPagesSearch(search);
            viewModel.MapIrregularities = this.irregularities.GetAll().ToList();

            foreach (var item in viewModel.Irregularities)
            {
                item.RatingsModel = new RatingViewModel();
                item.RatingsModel.IrregularityId = item.Id;
                item.RatingsModel.Ratings = this.ratings.GetByIrregularityId(item.Id);
            }

            return this.View(viewModel);
        }
        [Authorize]
        public ActionResult Details(int id, int page = 1)
        {
            var idea = this.irregularities.GetById(id);
            var comments = this.comments.GetByIrregularityId(id, page).To<CommentViewModel>().ToList();

            var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<IrregularityDetailsViewModel>(idea);

            viewModel.Comments = comments;
            viewModel.PagesCount = this.comments.GetPagesByIrregularityId(id);

            return this.View(viewModel);
        }
    }
}