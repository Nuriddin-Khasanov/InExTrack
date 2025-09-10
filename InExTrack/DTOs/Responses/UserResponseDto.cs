namespace InExTrack.DTOs.Responses
{
    public class UserResponseDto
    {
        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public IFormFile? ImageURL { get; set; }
    }
}
