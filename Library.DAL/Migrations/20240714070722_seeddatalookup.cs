using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class seeddatalookup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "lookUpCategory",
                columns: new[] { "Id", "Code", "CreateAt", "Description", "Name" },
                values: new object[] { 1, 1, new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7312), null, "TypeOfShelf" });

            migrationBuilder.InsertData(
                table: "lookUp",
                columns: new[] { "Id", "ArabicName", "CreateAt", "Description", "FrenchName", "LookUpCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "دراما", new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7430), null, "drame", 1, "Drama" },
                    { 2, "أعمال", new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7432), null, "entreprise", 1, "business" },
                    { 3, "خيال علمي", new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7433), null, "la science-fiction", 1, "Science fiction" },
                    { 4, "فانتازي", new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7434), null, "Fantaisie", 1, "Fantasy" },
                    { 5, "تشويق", new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7435), null, "le film à suspense", 1, "Thriller" },
                    { 6, "غموض", new DateTime(2024, 7, 14, 7, 7, 21, 30, DateTimeKind.Utc).AddTicks(7436), null, "Mystère", 1, "Mystery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "lookUpCategory",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
