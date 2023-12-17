namespace Entity.Console.Seeds;

using Entity.Console.Data;
using Entity.Console.Models;
using System.Collections.Generic;

public static class SeedUsers
{
    public static void Seed()
    {
        using var context = new AppDbContext();

        var newSeller = new User
        {
            Username = "nakamoto",
            Credential = new()
            {
                HashedPassword = "#hashed#",
                Salt = "random_salt",
                HashAlgorithm = "manual",
            },
            Profile = new()
            {
                Email = "mumkhong@skiff.com",
                Phone = "(+60) 12 345 4567",
                FirstName = "Satoshi",
                LastName = "Nakamoto",
                Address = new()
                {
                    Street1 = "456 Vietz Street",
                    Street2 = "4Floor Liu Thinh",
                    City = "Da Nang",
                    PostalCode = "12345",
                    State = "Quang Nam",
                    Country = "Vietnam",
                },
            },
            Shop = new()
            {
                Name = "My Shop",
                Description = "It sells a lot of cool stuffs",
                Address = new()
                {
                    Street1 = "789 Vietz Street",
                    Street2 = "9Floor Liu Thinh",
                    City = "Da Nang",
                    PostalCode = "12345",
                    State = "Quang Nam",
                    Country = "Vietnam",
                },
                Products = new List<Product>()
                {
                    new()
                    {
                        Name = "Product 1",
                        Description = "Description for product 1",
                        Price = 10.99m,
                    },
                    new()
                    {
                        Name = "Product 2",
                        Description = "Description for product 2",
                        Price = 10.99m,
                    },
                },
            },
        };

        var newUser = new User
        {
            Username = "user001",
            Credential = new()
            {
                HashedPassword = "#hashed#",
                Salt = "random_salt",
                HashAlgorithm = "manual",
            },
            Profile = new()
            {
                Email = "user@skiff.com",
                Phone = "(+60) 12 345 4567",
                FirstName = "User",
                LastName = "User",
                Address = new()
                {
                    Street1 = "456 Vietz Street",
                    Street2 = "4Floor Liu Thinh",
                    City = "Da Nang",
                    PostalCode = "12345",
                    State = "Quang Nam",
                    Country = "Vietnam",
                },
            },
        };

        context.Add(newSeller);
        context.Add(newUser);

        context.SaveChanges();
    }
}
