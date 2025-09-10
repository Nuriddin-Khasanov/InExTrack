using InExTrack.Common;

namespace InExTrack.Models
{
    public class CategoryFile : DataFile
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();
    }
}
