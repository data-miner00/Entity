using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Console.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "nakamoto" },
                    { 2L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "user001" }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "CreatedAt", "HashAlgorithm", "HashedPassword", "Salt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "manual", "#hashed#", "random_salt", 1L },
                    { 2L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "manual", "#hashed#", "random_salt", 2L }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "OwnerId" },
                values: new object[] { 1L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "It sells a lot of cool stuffs", "My Shop", 1L });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Phone", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "mumkhong@skiff.com", "Satoshi", "Nakamoto", "(+60) 12 345 4567", 1L },
                    { 2L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "user@skiff.com", "User", "User", "(+60) 12 345 4567", 2L }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CreatedAt", "PostalCode", "ShopId", "State", "Street1", "Street2", "UserProfileId" },
                values: new object[,]
                {
                    { 1L, "Da Nang", "Vietnam", new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "12345", null, "Quang Nam", "456 Dha Street", "4Floor Liu Thinh", 1L },
                    { 2L, "Da Nang", "Vietnam", new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "12345", 1L, "Quang Nam", "789 Vietz Street", "9Floor Liu Thinh", null },
                    { 3L, "Da Nang", "Vietnam", new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "12345", null, "Quang Nam", "456 Linh Street", "4Floor Liu Thinh", 2L }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "SellerId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "Description for product 1", "Product 1", 10.99m, 1L },
                    { 2L, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), "Description for product 2", "Product 2", 10.99m, 1L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
