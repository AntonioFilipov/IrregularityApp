namespace MvcTemplate.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentAddViewModel
    {
        [Required]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}