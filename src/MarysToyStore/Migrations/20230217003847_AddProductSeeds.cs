using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarysToyStore.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A toy car that goes really fast.", "/bluecar.jpg", "Car", 3.99m },
                    { 2, "Toy ducks that float.", "/ducks.jpg", "Ducks", 10.99m },
                    { 3, "A toy to build your ideas.", "/legos.jpg", "Legos", 25.99m },
                    { 4, "An advanced toy that will make anybody happy.", "/robot.jpg", "Robot", 15.99m },
                    { 5, "A soft bear that is comforting to touch.", "/teddy.jpg", "Teddy", 29.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
