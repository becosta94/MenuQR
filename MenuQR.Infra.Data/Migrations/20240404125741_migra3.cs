using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuQR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migra3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductOffList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    BillCompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerDocument = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOffList", x => new { x.Id, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_ProductOffList_Bill_BillId_BillCompanyId",
                        columns: x => new { x.BillId, x.BillCompanyId },
                        principalTable: "Bill",
                        principalColumns: new[] { "Id", "CompanyId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOffList_Customer_CustomerDocument",
                        column: x => x.CustomerDocument,
                        principalTable: "Customer",
                        principalColumn: "CustomerDocument",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(749), new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(933), new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(939), new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(944), new DateTime(2024, 4, 4, 9, 57, 41, 53, DateTimeKind.Local).AddTicks(945) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(161), new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(336), new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(336) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(341), new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(346), new DateTime(2024, 4, 4, 9, 57, 41, 54, DateTimeKind.Local).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedAt", "Link", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 57, 41, 56, DateTimeKind.Local).AddTicks(2624), "https://localhost:44361/1/6/customer/login/", new DateTime(2024, 4, 4, 9, 57, 41, 56, DateTimeKind.Local).AddTicks(2634) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOffList_BillId_BillCompanyId",
                table: "ProductOffList",
                columns: new[] { "BillId", "BillCompanyId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOffList_CustomerDocument",
                table: "ProductOffList",
                column: "CustomerDocument");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOffList");

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
                columns: new[] { "CreatedAt", "Link", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 21, 16, 29, 225, DateTimeKind.Local).AddTicks(8912), "Teste", new DateTime(2024, 4, 2, 21, 16, 29, 225, DateTimeKind.Local).AddTicks(8917) });
        }
    }
}
