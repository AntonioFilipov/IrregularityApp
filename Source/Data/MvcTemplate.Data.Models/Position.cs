namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;

    public class Position : BaseModel<int>
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
