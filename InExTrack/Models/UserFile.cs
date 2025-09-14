using InExTrack.Common;

namespace InExTrack.Models
{
    public class UserFile: DataFile
    {
        public required Guid UserId { get; set; }
    }
}
