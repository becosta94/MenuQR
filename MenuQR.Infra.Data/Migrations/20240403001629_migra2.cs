using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuQR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QRLink",
                table: "Tables",
                newName: "Link");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1649), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1664) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1684), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1684) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1689), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1690) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1693), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3504), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3524), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3525) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3530), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3534), new DateTime(2024, 4, 2, 21, 16, 29, 224, DateTimeKind.Local).AddTicks(3535) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 225, DateTimeKind.Local).AddTicks(8912), new DateTime(2024, 4, 2, 21, 16, 29, 225, DateTimeKind.Local).AddTicks(8917) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Tables",
                newName: "QRLink");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5294), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5309) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5359), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5360) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5365), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5369), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(5370) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7044), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7049) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7063), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7064) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7067), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7068) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7071), new DateTime(2024, 4, 2, 20, 55, 47, 369, DateTimeKind.Local).AddTicks(7071) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 55, 47, 371, DateTimeKind.Local).AddTicks(783), new DateTime(2024, 4, 2, 20, 55, 47, 371, DateTimeKind.Local).AddTicks(788) });
        }
    }
}
