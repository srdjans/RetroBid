namespace AuctionService.Data.DTOs;

public class PlatformDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }  
    public string? Manufacturer { get; set; }  
    public int ReleaseYear { get; set; }
}
