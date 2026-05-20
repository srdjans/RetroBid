namespace AuctionService.DTOs;

public class UpdateAuctionDto
{
    public required decimal ReservePrice { get; set; }
    public required DateTime AuctionEnd { get; set; }
}
