using InExTrack.Common;

namespace InExTrack.Models
{
    public class Transaction_ : Entity
    {
        public Guid UserCategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string? Note { get; set; }
    }
}
