using AuctionService.Entities;
using AuctionService.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public static class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AuctionDbContext>();

        context.Database.Migrate();
        SeedPlatforms(context);
        SeedAuctions(context);
    }

    private static void SeedPlatforms(AuctionDbContext context)
    {
        if (context.Platforms.Any()) return;

        var platforms = new List<Platform>
        {
            // Nintendo
            new() { Id = Guid.NewGuid(), IsActive = true, Name = "NES", Manufacturer = "Nintendo", ReleaseYear = 1985 },
            new() { Id = Guid.NewGuid(), Name = "SNES", Manufacturer = "Nintendo", ReleaseYear = 1991 },
            new() { Id = Guid.NewGuid(), Name = "Nintendo 64", Manufacturer = "Nintendo", ReleaseYear = 1996 },
            new() { Id = Guid.NewGuid(), Name = "GameCube", Manufacturer = "Nintendo", ReleaseYear = 2001 },
            new() { Id = Guid.NewGuid(), Name = "Wii", Manufacturer = "Nintendo", ReleaseYear = 2006 },
            new() { Id = Guid.NewGuid(), Name = "Game Boy", Manufacturer = "Nintendo", ReleaseYear = 1989 },
            new() { Id = Guid.NewGuid(), Name = "Game Boy Color", Manufacturer = "Nintendo", ReleaseYear = 1998 },
            new() { Id = Guid.NewGuid(), Name = "Game Boy Advance", Manufacturer = "Nintendo", ReleaseYear = 2001 },
            new() { Id = Guid.NewGuid(), Name = "Nintendo DS", Manufacturer = "Nintendo", ReleaseYear = 2004 },

            // Sega
            new() { Id = Guid.NewGuid(), Name = "Master System", Manufacturer = "Sega", ReleaseYear = 1985 },
            new() { Id = Guid.NewGuid(), Name = "Genesis", Manufacturer = "Sega", ReleaseYear = 1988 },
            new() { Id = Guid.NewGuid(), Name = "Saturn", Manufacturer = "Sega", ReleaseYear = 1994 },
            new() { Id = Guid.NewGuid(), Name = "Dreamcast", Manufacturer = "Sega", ReleaseYear = 1998 },
            new() { Id = Guid.NewGuid(), Name = "Game Gear", Manufacturer = "Sega", ReleaseYear = 1990 },

            // Sony
            new() { Id = Guid.NewGuid(), Name = "PlayStation", Manufacturer = "Sony", ReleaseYear = 1994 },
            new() { Id = Guid.NewGuid(), Name = "PlayStation 2", Manufacturer = "Sony", ReleaseYear = 2000 },
            new() { Id = Guid.NewGuid(), Name = "PSP", Manufacturer = "Sony", ReleaseYear = 2004 },

            // Atari
            new() { Id = Guid.NewGuid(), Name = "Atari 2600", Manufacturer = "Atari", ReleaseYear = 1977 },
            new() { Id = Guid.NewGuid(), Name = "Atari 5200", Manufacturer = "Atari", ReleaseYear = 1982 },
            new() { Id = Guid.NewGuid(), Name = "Jaguar", Manufacturer = "Atari", ReleaseYear = 1993 },

            // Other
            new() { Id = Guid.NewGuid(), Name = "Neo Geo", Manufacturer = "SNK", ReleaseYear = 1990 },
            new() { Id = Guid.NewGuid(), Name = "TurboGrafx-16", Manufacturer = "NEC", ReleaseYear = 1989 },
            new() { Id = Guid.NewGuid(), Name = "3DO", Manufacturer = "Panasonic", ReleaseYear = 1993 },
        };

        context.Platforms.AddRange(platforms);
        context.SaveChanges();
    }

    private static void SeedAuctions(AuctionDbContext context)
    {
        if (context.Auctions.Any()) return;

        var snes = context.Platforms.First(p => p.Name == "SNES");
        var n64 = context.Platforms.First(p => p.Name == "Nintendo 64");
        var ps2 = context.Platforms.First(p => p.Name == "PlayStation 2");
        var dreamcast = context.Platforms.First(p => p.Name == "Dreamcast");

        var auctions = new List<Auction>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Seller = "retrogamer_42",
                ReservePrice = 800m,
                AuctionEnd = DateTime.UtcNow.AddDays(7),
                Status = AuctionStatus.Live,
                Items =
                {
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Game,
                        Title = "Chrono Trigger",
                        ReleaseYear = 1995,
                        Region = "NTSC-U",
                        Description = "Factory sealed. Owned since 1995, stored in climate-controlled environment.",
                        Condition = ItemCondition.Sealed,
                        HasOriginalPackaging = true,
                        ImageUrl = "https://example.com/images/chrono-trigger-sealed.jpg",
                        PlatformId = snes.Id
                    }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Seller = "console_collector",
                ReservePrice = 150m,
                AuctionEnd = DateTime.UtcNow.AddDays(5),
                Status = AuctionStatus.Live,
                Items =
                {
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Console,
                        Title = "Nintendo 64 Console - Atomic Purple",
                        ReleaseYear = 1996,
                        Region = "NTSC-U",
                        Description = "Rare Atomic Purple variant. Includes original controller and AV cables. Tested and working.",
                        Condition = ItemCondition.Good,
                        HasOriginalPackaging = false,
                        ImageUrl = "https://example.com/images/n64-atomic-purple.jpg",
                        PlatformId = n64.Id
                    }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Seller = "estate_seller_99",
                ReservePrice = 200m,
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Status = AuctionStatus.Live,
                Items =
                {
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Console,
                        Title = "PlayStation 2 Slim Console",
                        ReleaseYear = 2004,
                        Region = "NTSC-U",
                        Description = "Slim model with original controller, memory card, and AV cables.",
                        Condition = ItemCondition.Good,
                        HasOriginalPackaging = false,
                        ImageUrl = "https://example.com/images/ps2-slim.jpg",
                        PlatformId = ps2.Id
                    },
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Game,
                        Title = "Final Fantasy X",
                        ReleaseYear = 2001,
                        Region = "NTSC-U",
                        Description = "Complete with manual.",
                        Condition = ItemCondition.LikeNew,
                        HasOriginalPackaging = true,
                        ImageUrl = "https://example.com/images/ffx.jpg",
                        PlatformId = ps2.Id
                    },
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Game,
                        Title = "Shadow of the Colossus",
                        ReleaseYear = 2005,
                        Region = "NTSC-U",
                        Description = "Disc in excellent condition, case slightly scuffed.",
                        Condition = ItemCondition.Good,
                        HasOriginalPackaging = true,
                        ImageUrl = "https://example.com/images/shadow-colossus.jpg",
                        PlatformId = ps2.Id
                    },
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Accessory,
                        Title = "DualShock 2 Controller (Black)",
                        Description = "Lightly used spare controller, all buttons responsive.",
                        Condition = ItemCondition.Good,
                        HasOriginalPackaging = false,
                        ImageUrl = "https://example.com/images/dualshock2.jpg",
                        PlatformId = ps2.Id
                    }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Seller = "retrogamer_42",
                Winner = "dreamcast_fan",
                ReservePrice = 75m,
                SoldAmount = 95m,
                CurrentHighBid = 95m,
                AuctionEnd = DateTime.UtcNow.AddDays(-2),
                Status = AuctionStatus.Finished,
                Items =
                {
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Game,
                        Title = "Skies of Arcadia",
                        ReleaseYear = 2000,
                        Region = "NTSC-U",
                        Description = "Complete in case with both discs and manual.",
                        Condition = ItemCondition.Good,
                        HasOriginalPackaging = true,
                        ImageUrl = "https://example.com/images/skies-of-arcadia.jpg",
                        PlatformId = dreamcast.Id
                    }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Seller = "console_collector",
                ReservePrice = 1500m,
                CurrentHighBid = 900m,
                AuctionEnd = DateTime.UtcNow.AddDays(-1),
                Status = AuctionStatus.ReserveNotMet,
                Items =
                {
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Type = ItemType.Game,
                        Title = "EarthBound",
                        ReleaseYear = 1995,
                        Region = "NTSC-U",
                        Description = "Complete in box with player's guide and scratch-n-sniff cards.",
                        Condition = ItemCondition.LikeNew,
                        HasOriginalPackaging = true,
                        ImageUrl = "https://example.com/images/earthbound.jpg",
                        PlatformId = snes.Id
                    }
                }
            }
        };

        context.Auctions.AddRange(auctions);
        context.SaveChanges();
    }
}
