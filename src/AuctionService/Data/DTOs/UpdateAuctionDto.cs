namespace AuctionService.Data.DTOs;

public class UpdateAuctionDto
{
    public decimal? ReservePrice { get; set; }
    public DateTime? AuctionEnd { get; set; }
}
