using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Console.Migrations
{
    /// <inheritdoc />
    public partial class Add_OrderUnitPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderUnitPrice",
                table: "OrderDetails",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderUnitPrice",
                table: "OrderDetails");
        }
    }
}
