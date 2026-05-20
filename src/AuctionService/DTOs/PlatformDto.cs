namespace AuctionService.DTOs;

public class PlatformDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }  
    public string? Manufacturer { get; set; }  
    public required int ReleaseYear { get; set; }
}
