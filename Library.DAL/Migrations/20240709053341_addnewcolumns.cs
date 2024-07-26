using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "shelves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "shelves",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "shelves",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "books",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "books");

            migrationBuilder.DropColumn(
                name: "price",
                table: "books");

            migrationBuilder.InsertData(
                table: "shelves",
                columns: new[] { "Id", "ArabicName", "BookCount", "EnglishName", "FrenchName" },
                values: new object[,]
                {
                    { 1, "المالية", null, "Finance", "financement" },
                    { 2, "جريمة", null, "Crime", "criminalité " },
                    { 3, "دراما", null, "Drama", "dramatique" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "ArabicName", "FrenchName", "Image", "Name", "ShelfId" },
                values: new object[,]
                {
                    { 1, "الاب الفقير و الغني", "Papa riche, papa pauvre", "", "Rich Dad Poor Dad", 1 },
                    { 2, "في دم بارد", "De sang-froid", "", "In Cold Blood", 2 },
                    { 3, "الظلام في المدينة", "L'ombre dans la ville", "", "The shadow in the city", 3 },
                    { 4, "الحديقة", "le jardin", "", "The Garden", 3 }
                });
        }
    }
}
