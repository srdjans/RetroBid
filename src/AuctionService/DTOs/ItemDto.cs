using AuctionService.Entities.Enums;

namespace AuctionService.DTOs;

public class ItemDto
{
    public required Guid Id { get; set; }
    public required ItemType Type { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Region { get; set; }
    public required ItemCondition Condition { get; set; }
    public required bool HasOriginalPackaging { get; set; }
    public string? ImageUrl { get; set; }
    public required string PlatformName { get; set; }
    public string? Manufacturer { get; set; }
}
