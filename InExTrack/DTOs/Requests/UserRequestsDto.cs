using InExTrack.Enums;
using System.ComponentModel.DataAnnotations;

namespace InExTrack.DTOs.Requests
{
    public class UserRequestsDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        
        public string? ImageURL { get; set; }
    }
}
