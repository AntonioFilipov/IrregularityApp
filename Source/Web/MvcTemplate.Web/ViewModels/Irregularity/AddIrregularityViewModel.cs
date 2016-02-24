namespace MvcTemplate.Web.ViewModels.Irregularity
{
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web;

    public class AddIrregularityViewModel : IMapFrom<Data.Models.Irregularity>
    {

        [Required]
        [StringLength(50)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [StringLength(1000)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}