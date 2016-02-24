namespace MvcTemplate.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using AutoMapper;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
        }

        public PostCommentViewModel(int irregularityId)
        {
            this.IrregularityId = irregularityId;
        }

        public int IrregularityId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 100)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}