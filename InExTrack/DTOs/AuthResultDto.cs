using InExTrack.Models;

namespace InExTrack.DTOs
{
    public class AuthResultDto
    {
        public User User { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
    }
}
