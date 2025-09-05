using InExTrack.Enums;
using System.ComponentModel.DataAnnotations;

namespace InExTrack.DTOs.Requests
{
    public class UserRequestsDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Имя пользователя должно содержать минимум 3 символа")]
        public string? UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public string? PasswordHash { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Имя пользователя должно содержать минимум 3 символа")]
        public string? FullName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        
        public string? ImageURL { get; set; }
    }
}
