namespace MvcTemplate.Web.ViewModels.Irregularity
{
    using System.Collections.Generic;
    using MvcTemplate.Data.Models;

    public class IrregularityInfo
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }


        public virtual ApplicationUser Author { get; set; }


        public virtual Category Category { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}