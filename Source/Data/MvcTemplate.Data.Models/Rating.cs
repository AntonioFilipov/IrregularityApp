namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class Rating : BaseModel<int>
    {
        public int IrregularityId { get; set; }

        public virtual Irregularity Irregularity { get; set; }

        [Range(0, 1)]
        [DefaultValue(0)]
        public int Points { get; set; }
    }
}
