using AuctionService.DTOs;
using AuctionService.Entities;

namespace AuctionService.Mappers;

public static class ItemMappers
{
    public static ItemDto ToDto(this Item entity)
    {
        return new ItemDto
        {
            Id = entity.Id,
            Type = entity.Type,
            Title = entity.Title,
            Description = entity.Description,
            ReleaseYear = entity.ReleaseYear,
            Region = entity.Region,
            Condition = entity.Condition,
            HasOriginalPackaging = entity.HasOriginalPackaging,
            ImageUrl = entity.ImageUrl,
            PlatformName = entity.Platform.Name,
            Manufacturer = entity.Platform.Manufacturer,
        };
    }

    public static Item ToEntity(this CreateItemDto dto)
    {
        return new Item
        {
            Id = Guid.NewGuid(),
            Type = dto.Type,
            Title = dto.Title,
            Description = dto.Description,
            ReleaseYear = dto.ReleaseYear,
            Region = dto.Region,
            Condition = dto.Condition,
            HasOriginalPackaging = dto.HasOriginalPackaging,
            ImageUrl = dto.ImageUrl,
            PlatformId = dto.PlatformId
        };
    }

    public static void ApplyTo(this UpdateItemDto dto, Item entity)
    {
        entity.Type = dto.Type;
        entity.Title = dto.Title ?? entity.Title;
        entity.Description = dto.Description ?? entity.Description;
        entity.ReleaseYear = dto.ReleaseYear ?? entity.ReleaseYear;
        entity.Region = dto.Region ?? entity.Region;
        entity.Condition = dto.Condition;
        entity.HasOriginalPackaging = dto.HasOriginalPackaging;
        entity.ImageUrl = dto.ImageUrl ?? entity.ImageUrl;
        // Note: PlatformId is not updated here to avoid unintended platform changes
    }
}
