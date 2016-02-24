namespace MvcTemplate.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IrregularityViewModel> Jokes { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
