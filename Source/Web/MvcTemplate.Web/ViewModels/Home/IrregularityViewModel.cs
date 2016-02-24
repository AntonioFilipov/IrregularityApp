namespace MvcTemplate.Web.ViewModels.Home
{
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Rating;
    using AutoMapper;

    public class IrregularityViewModel : IMapFrom<Data.Models.Irregularity>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CommentsCount { get; set; }

        public RatingViewModel RatingsModel { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Irregularity, IrregularityViewModel>()
                   .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}