using InExTrack.Common;

namespace InExTrack.Models
{
    public class UserFile(Guid userId, string name, string url, long size, string extension): DataFile(name, url, size, extension)
    {
        public Guid UserId { get; set; } = userId;
    }
}
