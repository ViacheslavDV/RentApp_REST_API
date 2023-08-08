using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentApp_REST_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CreatedDate", "Description", "Details", "HorsePower", "ImageUrl", "Model", "Price", "Rating", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", 250, "", "Camry", 300, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 },
                    { 2, "Mercedes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", 330, "", "S-Class W223", 800, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
