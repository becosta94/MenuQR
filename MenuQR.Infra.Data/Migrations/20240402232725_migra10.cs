using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuQR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migra10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldValues",
                table: "AuditLogs",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "NewValues",
                table: "AuditLogs",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "AffectedColumns",
                table: "AuditLogs",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5296), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5312) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5330), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5334), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5334) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5338), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7045), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7087), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7088) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7091), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7091) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7093), new DateTime(2024, 4, 2, 20, 27, 25, 329, DateTimeKind.Local).AddTicks(7094) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 27, 25, 330, DateTimeKind.Local).AddTicks(6469), new DateTime(2024, 4, 2, 20, 27, 25, 330, DateTimeKind.Local).AddTicks(6473) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldValues",
                table: "AuditLogs",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NewValues",
                table: "AuditLogs",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AffectedColumns",
                table: "AuditLogs",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8279), new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8308), new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8312), new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8317), new DateTime(2024, 4, 2, 20, 19, 13, 749, DateTimeKind.Local).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(157), new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(163) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(176), new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(177) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(180), new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(183), new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(183) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(8207), new DateTime(2024, 4, 2, 20, 19, 13, 750, DateTimeKind.Local).AddTicks(8210) });
        }
    }
}
