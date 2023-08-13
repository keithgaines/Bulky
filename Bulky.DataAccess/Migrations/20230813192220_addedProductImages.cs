using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "C:\\repos\\Bulky\\BulkyWeb\\wwwroot\\images\\product\\fortuneoftime.jpg", 1 },
                    { 2, "C:\\repos\\Bulky\\BulkyWeb\\wwwroot\\images\\product\\darkskies.jpg", 2 },
                    { 3, "C:\\repos\\Bulky\\BulkyWeb\\wwwroot\\images\\product\\vanishinthesunset.jpg", 3 },
                    { 4, "~/images/product/cottoncandy.jpg", 4 },
                    { 5, "~/images/product/cottoncandy.jpg", 5 },
                    { 6, "~/images/product/leavesandwonders.jpg", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
