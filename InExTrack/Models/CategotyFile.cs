using InExTrack.Common;

namespace InExTrack.Models
{
    public class CategotyFile(Guid categoryId, string name, string url, long size, string extension) : DataFile(name, url, size, extension)
    {
        public Guid CategoryId { get; set; } = categoryId;
    }
}
