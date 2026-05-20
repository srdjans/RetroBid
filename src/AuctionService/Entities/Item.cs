using AuctionService.Entities.Enums;

namespace AuctionService.Entities;

public class Item
{
    // Required
    public required Guid Id { get; set; }
    public required ItemType Type { get; set; }
    public required string Title { get; set; }
    public required ItemCondition Condition { get; set; }
    public required bool HasOriginalPackaging { get; set; }

    // Optional
    public string? Description { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Region { get; set; }
    public string? ImageUrl { get; set; }

    // Navigation
    public required Guid PlatformId { get; set; }
    public Platform Platform { get; set; } = null!;
    public Guid AuctionId { get; set; }
    public Auction Auction { get; set; } = null!;
}
