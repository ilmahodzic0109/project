using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesDAL.Migrations
{
    /// <inheritdoc />
    public partial class productUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Products");
        }
    }
}
