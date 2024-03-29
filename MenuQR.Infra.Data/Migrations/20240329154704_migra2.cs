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
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Company");

            migrationBuilder.AddColumn<Guid>(
                name: "Unique",
                table: "Tables",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BillClosureOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CloseTotal = table.Column<bool>(type: "bit", nullable: false),
                    OrderCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CustumerDocument = table.Column<string>(type: "varchar(50)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillClosureOrder", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumns: new[] { "CompanyId", "Id" },
                keyValues: new object[] { 1, 1 },
                column: "Unique",
                value: new Guid("440cdeee-5b8a-462a-96fd-20b24bd82f55"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_Company",
                table: "BillClosureOrder",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillClosureOrder");

            migrationBuilder.DropColumn(
                name: "Unique",
                table: "Tables");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyId",
                value: 1);
        }
    }
}
