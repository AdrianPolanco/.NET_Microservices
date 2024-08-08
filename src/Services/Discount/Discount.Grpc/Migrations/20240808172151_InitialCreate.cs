using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.Grpc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[,]
                {
                    { new Guid("0e4a3bf0-eb2c-4548-8ece-f7adcae210c0"), 20, "Nintendo Switch Discount", "Nintendo Switch" },
                    { new Guid("7c21da51-8bb8-4c85-83af-8b9246bf4f89"), 50, "iPhoneX Discount", "iPhone X" },
                    { new Guid("d85fb4e4-c70c-49d0-986a-c63dc4b1beed"), 10, "Samsung Galaxy S24 Discount", "Samsung Galaxy S24" },
                    { new Guid("e81f7936-757a-4980-8965-3a3a583470b3"), 50, "Asus TUF A15 Discount", "Asus TUF A15" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
