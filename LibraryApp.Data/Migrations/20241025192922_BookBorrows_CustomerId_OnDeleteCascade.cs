using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookBorrows_CustomerId_OnDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Customers_CustomerId",
                table: "BookBorrows");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(561), new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(562) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(567), new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(568) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(572), new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "BookBorrows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1472), new DateTime(2024, 11, 8, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "BookBorrows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1480), new DateTime(2024, 11, 8, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 29, 21, 728, DateTimeKind.Utc).AddTicks(1252));

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Customers_CustomerId",
                table: "BookBorrows",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Customers_CustomerId",
                table: "BookBorrows");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1178), new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1179) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1185), new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1186) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1190), new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "BookBorrows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1894), new DateTime(2024, 11, 7, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1895) });

            migrationBuilder.UpdateData(
                table: "BookBorrows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpiryDate" },
                values: new object[] { new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1902), new DateTime(2024, 11, 7, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1903) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1675));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Customers_CustomerId",
                table: "BookBorrows",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
