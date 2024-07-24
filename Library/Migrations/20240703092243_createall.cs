using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class createall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrenchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shelves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "shelves",
                columns: new[] { "Id", "ArabicName", "EnglishName", "FrenchName" },
                values: new object[,]
                {
                    { 1, "المالية", "Finance", "financement" },
                    { 2, "جريمة", "Crime", "criminalité " },
                    { 3, "دراما", "Drama", "dramatique" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Name", "ShelfId" },
                values: new object[,]
                {
                    { 1, "Rich Dad Poor Dad", 1 },
                    { 2, "In Cold Blood", 2 },
                    { 3, "In Cold Blood", 3 },
                    { 4, "Test", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_ShelfId",
                table: "books",
                column: "ShelfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "shelves");
        }
    }
}
