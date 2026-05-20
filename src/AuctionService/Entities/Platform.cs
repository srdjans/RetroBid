namespace AuctionService.Entities;

public class Platform
{
    // Required
    public required Guid Id { get; set; }
    public required string Name { get; set; }  // "PlayStation"
    public required int ReleaseYear { get; set; }

    // Defaulted
    public bool IsActive { get; set; } = true; // for soft retirement

    // Optional
    public string? Manufacturer { get; set; }  // "Sony"
    
    // Navigation
    public ICollection<Item> Items { get; set; } = new List<Item>();
}
