using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiFirst.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Smith" },
                    { 3, "Mike", "Johnson" },
                    { 4, "Emily", "Davis" },
                    { 5, "Sarah", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Discount", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10.00m, "Product 1", 100.00m },
                    { 2, 15.00m, "Product 2", 150.00m },
                    { 3, 20.00m, "Product 3", 200.00m },
                    { 4, 25.00m, "Product 4", 250.00m },
                    { 5, 30.00m, "Product 5", 300.00m },
                    { 6, 35.00m, "Product 6", 350.00m },
                    { 7, 40.00m, "Product 7", 400.00m },
                    { 8, 45.00m, "Product 8", 450.00m },
                    { 9, 50.00m, "Product 9", 500.00m },
                    { 10, 55.00m, "Product 10", 550.00m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 31, 23, 58, 0, 989, DateTimeKind.Local).AddTicks(2451), 1 },
                    { 2, 2, new DateTime(2024, 8, 31, 23, 58, 0, 989, DateTimeKind.Local).AddTicks(2461), 2 },
                    { 3, 3, new DateTime(2024, 8, 31, 23, 58, 0, 989, DateTimeKind.Local).AddTicks(2462), 3 },
                    { 4, 4, new DateTime(2024, 8, 31, 23, 58, 0, 989, DateTimeKind.Local).AddTicks(2463), 4 },
                    { 5, 5, new DateTime(2024, 8, 31, 23, 58, 0, 989, DateTimeKind.Local).AddTicks(2464), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

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
