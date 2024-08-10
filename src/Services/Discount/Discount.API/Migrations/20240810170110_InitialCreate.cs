using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.API.Migrations
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
                    { new Guid("3e26ecec-b0ed-4477-acb1-cf4e99c2ea34"), 10, "Samsung Galaxy S24 Discount", "Samsung Galaxy S24" },
                    { new Guid("4a27ace2-2847-4974-a0b7-ab29581959d8"), 50, "Asus TUF A15 Discount", "Asus TUF A15" },
                    { new Guid("67d67cfa-cbc9-4a34-aff9-5825894b88aa"), 50, "iPhoneX Discount", "iPhone X" },
                    { new Guid("df940598-8683-451a-8df9-d293943748be"), 20, "Nintendo Switch Discount", "Nintendo Switch" }
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
