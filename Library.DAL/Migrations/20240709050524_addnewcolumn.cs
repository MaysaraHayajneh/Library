using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCount",
                table: "shelves",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "shelves",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "shelves",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "shelves",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookCount",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCount",
                table: "shelves");
        }
    }
}
