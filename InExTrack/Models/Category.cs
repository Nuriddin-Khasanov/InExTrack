using InExTrack.Common;
using InExTrack.Enums;

namespace InExTrack.Models;

public class Category : Entity
{
    public string? Name { get; set; }
    public CategoryTypeEnum Type { get; set; } // income or expense
}
//public class Category : Entity
