namespace Entity.Console.Seeds;

using Entity.Console.Models;
using Microsoft.EntityFrameworkCore;

public static partial class Seedings
{
    private static readonly DateTime FixedTime = new(2023, 3, 12, 0, 0, 0, DateTimeKind.Local);

    public static void SeedUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .SeedUsersSeparately()
            .SeedCredentials()
            .SeedProfiles()
            .SeedShops()
            .SeedAddresses()
            .SeedProducts();
    }

    private static ModelBuilder SeedUsersSeparately(this ModelBuilder modelBuilder)
    {
        var newSeller = new User
        {
            Id = 1,
            Username = "nakamoto",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        var newUser = new User
        {
            Id = 2,
            Username = "user001",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        modelBuilder.Entity<User>()
            .HasData(newSeller, newUser);

        return modelBuilder;
    }

    private static ModelBuilder SeedCredentials(this ModelBuilder modelBuilder)
    {
        var cred1 = new Credential
        {
            Id = 1,
            UserId = 1,
            HashedPassword = "#hashed#",
            Salt = "random_salt",
            HashAlgorithm = "manual",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        var cred2 = new Credential
        {
            Id = 2,
            UserId = 2,
            HashedPassword = "#hashed#",
            Salt = "random_salt",
            HashAlgorithm = "manual",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        modelBuilder.Entity<Credential>()
            .HasData(cred1, cred2);

        return modelBuilder;
    }

    private static ModelBuilder SeedProfiles(this ModelBuilder modelBuilder)
    {
        var prof1 = new UserProfile
        {
            Id = 1,
            UserId = 1,
            Email = "mumkhong@skiff.com",
            Phone = "(+60) 12 345 4567",
            FirstName = "Satoshi",
            LastName = "Nakamoto",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        var prof2 = new UserProfile
        {
            Id = 2,
            UserId = 2,
            Email = "user@skiff.com",
            Phone = "(+60) 12 345 4567",
            FirstName = "User",
            LastName = "User",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        modelBuilder.Entity<UserProfile>()
            .HasData(prof1, prof2);

        return modelBuilder;
    }

    private static ModelBuilder SeedAddresses(this ModelBuilder modelBuilder)
    {
        var add1 = new Address
        {
            Id = 1,
            UserProfileId = 1,
            Street1 = "456 Dha Street",
            Street2 = "4Floor Liu Thinh",
            City = "Da Nang",
            PostalCode = "12345",
            State = "Quang Nam",
            Country = "Vietnam",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        var add2 = new Address
        {
            Id = 2,
            ShopId = 1,
            Street1 = "789 Vietz Street",
            Street2 = "9Floor Liu Thinh",
            City = "Da Nang",
            PostalCode = "12345",
            State = "Quang Nam",
            Country = "Vietnam",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        var add3 = new Address
        {
            Id = 3,
            UserProfileId = 2,
            Street1 = "456 Linh Street",
            Street2 = "4Floor Liu Thinh",
            City = "Da Nang",
            PostalCode = "12345",
            State = "Quang Nam",
            Country = "Vietnam",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        modelBuilder.Entity<Address>()
            .HasData(add1, add2, add3);

        return modelBuilder;
    }

    private static ModelBuilder SeedShops(this ModelBuilder modelBuilder)
    {
        var shop1 = new Shop
        {
            Id = 1,
            OwnerId = 1,
            Name = "My Shop",
            Description = "It sells a lot of cool stuffs",
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        modelBuilder.Entity<Shop>()
            .HasData(shop1);

        return modelBuilder;
    }

    private static ModelBuilder SeedProducts(this ModelBuilder modelBuilder)
    {
        var prod1 = new Product
        {
            Id = 1,
            SellerId = 1,
            Name = "Product 1",
            Description = "Description for product 1",
            Price = 10.99m,
            UpdatedAt = FixedTime,
            CreatedAt = FixedTime,
        };

        var prod2 = new Product
        {
            Id = 2,
            SellerId = 1,
            Name = "Product 2",
            Description = "Description for product 2",
            Price = 10.99m,
            CreatedAt = FixedTime,
            UpdatedAt = FixedTime,
        };

        modelBuilder.Entity<Product>()
            .HasData(prod1, prod2);

        return modelBuilder;
    }
}
