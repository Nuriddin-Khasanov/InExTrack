using System.ComponentModel.DataAnnotations;

namespace InExTrack.DTOs.Requests
{
    public class RegisterRequest_
    {
        [Required]
        [MinLength(3, ErrorMessage = "Имя пользователя должно содержать минимум 3 символа")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public string Password { get; set; } = string.Empty;
    }
}
