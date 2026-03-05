using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForDifficultiesAndRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegionsDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionsDto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6bc3806b-51f5-4da7-8627-23d30d35c1a7"), "Medium" },
                    { new Guid("9225d853-e28b-4f41-ae85-82cd1e98b14d"), "Easy" },
                    { new Guid("aeedf08d-0179-4ed4-b3d3-9f3c810b083c"), "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionsDto");

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6bc3806b-51f5-4da7-8627-23d30d35c1a7"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9225d853-e28b-4f41-ae85-82cd1e98b14d"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("aeedf08d-0179-4ed4-b3d3-9f3c810b083c"));
        }
    }
}
