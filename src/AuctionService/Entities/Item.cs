using AuctionService.Entities.Enums;

namespace AuctionService.Entities;

public class Item
{
    public Guid Id { get; set; }

    // Core identification
    public ItemType Type { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Region { get; set; }

    // Condition
    public ItemCondition Condition { get; set; }
    public bool HasOriginalPackaging { get; set; }

    // Media
    public string? ImageUrl { get; set; }

    // Navigation
    public Guid PlatformId { get; set; }
    public Platform Platform { get; set; } = null!;
    public Guid AuctionId { get; set; }
    public Auction Auction { get; set; } = null!;
}