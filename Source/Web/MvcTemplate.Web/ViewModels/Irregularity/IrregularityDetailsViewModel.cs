namespace MvcTemplate.Web.ViewModels.Irregularity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Comments;
    using Data.Models;
    using Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Rating;

    public class IrregularityDetailsViewModel : IMapFrom<Irregularity>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ImageId { get; set; }

        public int CommentsCount { get; set; }

        public Position Position { get; set; }
        
        public int PagesCount { get; set; }

        public int RatingsCount { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public RatingViewModel RatingModel { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Irregularity, IrregularityDetailsViewModel>()
                   .ForMember(x => x.RatingsCount, opt => opt.MapFrom(x => x.Rating.Sum(v => v.Points)))
                   .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count()));
        }
    }
}