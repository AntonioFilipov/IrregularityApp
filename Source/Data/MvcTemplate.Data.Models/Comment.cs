namespace MvcTemplate.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [StringLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int IrregularityId { get; set; }

        public virtual Irregularity Irregularity { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
