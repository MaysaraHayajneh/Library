using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class addcolumstobook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FrenchName",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArabicName", "FrenchName" },
                values: new object[] { "الاب الفقير و الغني", "Papa riche, papa pauvre" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArabicName", "FrenchName" },
                values: new object[] { "في دم بارد", "De sang-froid" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArabicName", "FrenchName", "Name" },
                values: new object[] { "الظلام في المدينة", "L'ombre dans la ville", "The shadow in the city" });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArabicName", "FrenchName", "Name" },
                values: new object[] { "الحديقة", "le jardin", "The Garden" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicName",
                table: "books");

            migrationBuilder.DropColumn(
                name: "FrenchName",
                table: "books");

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "In Cold Blood");

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Test");
        }
    }
}
