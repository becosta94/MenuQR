using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderQR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "AuditLogs",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2156), new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2195), new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2195) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2200), new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2204), new DateTime(2024, 4, 15, 15, 14, 55, 864, DateTimeKind.Local).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3041), new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3045) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3060), new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3061) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3064), new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3065) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3067), new DateTime(2024, 4, 15, 15, 14, 55, 865, DateTimeKind.Local).AddTicks(3068) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 14, 55, 866, DateTimeKind.Local).AddTicks(8408), new DateTime(2024, 4, 15, 15, 14, 55, 866, DateTimeKind.Local).AddTicks(8412) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AuditLogs");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5917), new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5960), new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5960) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5965), new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5966) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5970), new DateTime(2024, 4, 12, 10, 49, 36, 111, DateTimeKind.Local).AddTicks(5970) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6353), new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6373), new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6373) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6377), new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6377) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6381), new DateTime(2024, 4, 12, 10, 49, 36, 112, DateTimeKind.Local).AddTicks(6381) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 10, 49, 36, 114, DateTimeKind.Local).AddTicks(1315), new DateTime(2024, 4, 12, 10, 49, 36, 114, DateTimeKind.Local).AddTicks(1318) });
        }
    }
}
