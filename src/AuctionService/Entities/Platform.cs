namespace AuctionService.Entities;

public class Platform
{
    public Guid Id { get; set; }
    public required string Name { get; set; }  // "PlayStation"
    public string? Manufacturer { get; set; }  // "Sony"
    public int ReleaseYear { get; set; }
    public bool IsActive { get; set; } = true; // for soft retirement

    // Navigation
    public ICollection<Item> Items { get; set; } = new List<Item>();
}