using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinShark.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Apple is a technology company.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Apple Stock" },
                    { 2, "Microsoft provides cloud and software services.", new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Microsoft Stock" },
                    { 3, "Alphabet is the parent company of Google.", new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Google Stock" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, "mahmoud@example.com", "REPLACE_WITH_HASHED_PASSWORD_1", "mahmoud" },
                    { 2, "ahmed@example.com", "REPLACE_WITH_HASHED_PASSWORD_2", "ahmed" },
                    { 3, "mona@example.com", "REPLACE_WITH_HASHED_PASSWORD_3", "mona" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "AppUserId", "Quantity", "StockId" },
                values: new object[,]
                {
                    { 1, 1, 10, 1 },
                    { 2, 2, 20, 2 },
                    { 3, 3, 30, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
