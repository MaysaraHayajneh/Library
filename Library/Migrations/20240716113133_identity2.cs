using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class identity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 31, 32, 676, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 31, 32, 676, DateTimeKind.Utc).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 31, 32, 676, DateTimeKind.Utc).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 31, 32, 676, DateTimeKind.Utc).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 31, 32, 676, DateTimeKind.Utc).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 31, 32, 676, DateTimeKind.Utc).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "lookUpCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 31, 32, 676, DateTimeKind.Utc).AddTicks(1125));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 22, 27, 625, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 22, 27, 625, DateTimeKind.Utc).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 22, 27, 625, DateTimeKind.Utc).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 22, 27, 625, DateTimeKind.Utc).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 22, 27, 625, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "lookUp",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 22, 27, 625, DateTimeKind.Utc).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "lookUpCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 7, 16, 11, 22, 27, 625, DateTimeKind.Utc).AddTicks(2175));
        }
    }
}
