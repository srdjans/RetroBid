using AuctionService.Entities.Enums;

namespace AuctionService.Data.DTOs;

public class CreateItemDto
{
    public required ItemType Type { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Region { get; set; }
    public required ItemCondition Condition { get; set; }
    public bool HasOriginalPackaging { get; set; }
    public string? ImageUrl { get; set; }
    public required Guid PlatformId { get; set; }
}
