namespace MvcTemplate.Web.ViewModels.Irregularity
{
    using System.Collections.Generic;
    using MvcTemplate.Web.ViewModels.Home;

    public class IrregularityAllViewModel
    {
        public int PagesCount { get; set; }

        public ICollection<IrregularityViewModel> Irregularities { get; set; }

        public IList<Data.Models.Irregularity> MapIrregularities { get; set; }
    }
}