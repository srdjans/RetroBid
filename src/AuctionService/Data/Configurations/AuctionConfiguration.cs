using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionService.Data.Configurations;

public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
        // Decimal precision for money fields
        builder.Property(a => a.ReservePrice)
            .HasPrecision(18, 2);

        builder.Property(a => a.SoldAmount)
            .HasPrecision(18, 2);

        builder.Property(a => a.CurrentHighBid)
            .HasPrecision(18, 2);

        // Store enum as string for schema evolution safety
        builder.Property(a => a.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Indexes for common marketplace queries
        builder.HasIndex(a => a.Status);
        builder.HasIndex(a => a.AuctionEnd);
        builder.HasIndex(a => a.Seller);
    }
}
