using InExTrack.Enums;
using System.ComponentModel.DataAnnotations;

namespace InExTrack.DTOs.Responses
{
    public class UserResponseDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public RoleEnum Role { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
    }
}
