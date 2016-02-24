namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Data.Common.Models;

    public class Irregularity : BaseModel<int>
    {
        private ICollection<Comment> comments;
        private ICollection<Rating> rating;

        public Irregularity()
        {
            this.comments = new HashSet<Comment>();
            this.rating = new HashSet<Rating>();
        }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Rating
        {
            get { return this.rating; }
            set { this.rating = value; }
        }
    }
}
