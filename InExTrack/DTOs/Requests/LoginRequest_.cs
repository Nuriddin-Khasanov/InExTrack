using System.ComponentModel.DataAnnotations;

namespace InExTrack.DTOs.Requests
{
    public class LoginRequest_
    {
        [Required]  // Атрибут объязательное поле
        public string Username { get; set; } = string.Empty;  //  

        [Required]
        public string Password { get; set; } = string.Empty; // 
    }
}
