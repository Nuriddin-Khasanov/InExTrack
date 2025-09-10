using InExTrack.Enums;

namespace InExTrack.DTOs
{
    public class CategoryDto
    {
        public string? Name { get; set; }
        public CategoryTypeEnum Type { get; set; } // income or expense
        public IFormFile? ImageURL { get; set; }
    }
}
