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
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_Id_CompanyId",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_Id_CompanyId",
                table: "OrderProduct");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId_OrderCompanyId",
                table: "OrderProduct",
                columns: new[] { "OrderId", "OrderCompanyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrderId_OrderCompanyId",
                table: "OrderProduct",
                columns: new[] { "OrderId", "OrderCompanyId" },
                principalTable: "Order",
                principalColumns: new[] { "Id", "CompanyId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrderId_OrderCompanyId",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_OrderId_OrderCompanyId",
                table: "OrderProduct");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_Id_CompanyId",
                table: "OrderProduct",
                columns: new[] { "Id", "CompanyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_Id_CompanyId",
                table: "OrderProduct",
                columns: new[] { "Id", "CompanyId" },
                principalTable: "Order",
                principalColumns: new[] { "Id", "CompanyId" });
        }
    }
}
