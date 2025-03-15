using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesDAL.Migrations
{
    /// <inheritdoc />
    public partial class updateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__versi__797309D9",
                table: "OrderDetails");

          //  migrationBuilder.DropIndex(
          //      name: "IX_OrderDetails_versionId",
           //     table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "versionId",
                table: "OrderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "versionId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_versionId",
                table: "OrderDetails",
                column: "versionId");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__versi__797309D9",
                table: "OrderDetails",
                column: "versionId",
                principalTable: "ProductVersions",
                principalColumn: "versionId");
        }
    }
}
