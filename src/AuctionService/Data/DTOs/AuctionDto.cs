using AuctionService.Entities.Enums;

namespace AuctionService.Data.DTOs;

public class AuctionDto
{
    public required Guid Id { get; set; }
    public required decimal ReservePrice { get; set; }
    public required string Seller { get; set; }
    public string? Winner { get; set; }
    public decimal? SoldAmount { get; set; }
    public decimal? CurrentHighBid { get; set; }
    public required DateTime CreatedAt { get; set; } 
    public required DateTime UpdatedAt { get; set; }
    public required DateTime AuctionEnd { get; set; }
    public required AuctionStatus Status { get; set; }
    public required List<ItemDto> Items { get; set; } = new();
}
