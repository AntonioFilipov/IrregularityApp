namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        private ICollection<Irregularity> irregularities;

        public Category()
        {
            this.irregularities = new HashSet<Irregularity>();
        }

        public string Name { get; set; }

        public virtual ICollection<Irregularity> Irregularities
        {
            get { return this.irregularities; }
            set { this.irregularities = value; }
        }
    }
}
