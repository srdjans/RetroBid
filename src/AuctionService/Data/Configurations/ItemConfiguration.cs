using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionService.Data.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        // Store enums as strings
        builder.Property(i => i.Type)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(i => i.Condition)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Indexes for filtering
        builder.HasIndex(i => i.Type);
        builder.HasIndex(i => i.Condition);
        builder.HasIndex(i => i.PlatformId);

        // One Auction has many Items; delete auction → delete its items
        builder.HasOne(i => i.Auction)
            .WithMany(a => a.Items)
            .HasForeignKey(i => i.AuctionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Item references one Platform; can't delete a platform that's still in use
        builder.HasOne(i => i.Platform)
            .WithMany(p => p.Items)
            .HasForeignKey(i => i.PlatformId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
