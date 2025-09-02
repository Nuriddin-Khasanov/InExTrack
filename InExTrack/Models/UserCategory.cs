using InExTrack.Common;

namespace InExTrack.Models
{
    public class UserCategory: Entity
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
