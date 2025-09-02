using InExTrack.Common;
using InExTrack.Enums;
using System.ComponentModel.DataAnnotations;

namespace InExTrack.Models
{
    public class User: Entity
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [Required]
        public string? PhoneNumber { get; set; }
        public string? ImageURL { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
