using AuctionService.DTOs;
using AuctionService.Entities;
using AuctionService.Entities.Enums;

namespace AuctionService.Mappers;

public static class AuctionMappers
{
    public static AuctionDto ToDto(this Auction entity)
    {
        return new AuctionDto
        {
            Id = entity.Id,
            ReservePrice = entity.ReservePrice,
            Seller = entity.Seller,
            Winner = entity.Winner,
            SoldAmount = entity.SoldAmount,
            CurrentHighBid = entity.CurrentHighBid,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            AuctionEnd = entity.AuctionEnd,
            Status = entity.Status,
            Items = entity.Items.Select(i => i.ToDto()).ToList()
        };
    }

    public static Auction ToEntity(this CreateAuctionDto dto, string seller)
    {
        return new Auction
        {
            Id = Guid.NewGuid(),
            ReservePrice = dto.ReservePrice,
            Seller = seller,
            Winner = null,
            SoldAmount = null,
            CurrentHighBid = null,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            AuctionEnd = dto.AuctionEnd,
            Status = AuctionStatus.Live,
            Items = dto.Items.Select(i => i.ToEntity()).ToList()
        };
    }

    public static void ApplyTo(this UpdateAuctionDto dto, Auction entity)
    {
        entity.ReservePrice = dto.ReservePrice;
        entity.AuctionEnd = dto.AuctionEnd;
        entity.UpdatedAt = DateTime.UtcNow;
    }
}
