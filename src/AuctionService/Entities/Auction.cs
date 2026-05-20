using AuctionService.Entities.Enums;

namespace AuctionService.Entities;

public class Auction
{
    // Required
    public required Guid Id { get; set; }
    public required string Seller { get; set; }
    public required decimal ReservePrice { get; set; }
    public required DateTime AuctionEnd { get; set; }

    // Defaulted
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public AuctionStatus Status { get; set; } = AuctionStatus.Live;

    // Optional
    public string? Winner { get; set; }
    public decimal? SoldAmount { get; set; }
    public decimal? CurrentHighBid { get; set; }

    // Navigation
    public ICollection<Item> Items { get; set; } = null!;
}
