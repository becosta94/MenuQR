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
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Tables_TableCompanyId_CompanyId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_TableCompanyId_CompanyId",
                table: "Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_TableId_TableCompanyId",
                table: "Bill",
                columns: new[] { "TableId", "TableCompanyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Tables_TableId_TableCompanyId",
                table: "Bill",
                columns: new[] { "TableId", "TableCompanyId" },
                principalTable: "Tables",
                principalColumns: new[] { "Id", "CompanyId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Tables_TableId_TableCompanyId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_TableId_TableCompanyId",
                table: "Bill");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_TableCompanyId_CompanyId",
                table: "Bill",
                columns: new[] { "TableCompanyId", "CompanyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Tables_TableCompanyId_CompanyId",
                table: "Bill",
                columns: new[] { "TableCompanyId", "CompanyId" },
                principalTable: "Tables",
                principalColumns: new[] { "Id", "CompanyId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
