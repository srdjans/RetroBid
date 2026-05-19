namespace AuctionService.Data.DTOs;

public class CreateAuctionDto
{
    public required decimal ReservePrice { get; set; }
    public required DateTime AuctionEnd { get; set; }
    public required List<CreateItemDto> Items { get; set; }
}
