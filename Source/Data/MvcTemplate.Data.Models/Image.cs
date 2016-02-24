namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
