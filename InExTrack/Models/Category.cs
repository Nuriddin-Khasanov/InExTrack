using InExTrack.Common;
using InExTrack.Enums;

namespace InExTrack.Models;

public class Category : Entity
{
    public string? Name { get; set; }
    public CategoryTypeEnum Type { get; set; } // income or expense
    public string? Description { get; set; }
    public CategoryFile? Image { get; set; }
    public List<UserCategory> UserCategories { get; set; } = new();
}
