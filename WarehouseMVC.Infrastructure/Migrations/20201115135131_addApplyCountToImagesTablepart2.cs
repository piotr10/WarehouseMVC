using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class addApplyCountToImagesTablepart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyCount",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ApplyCount",
                table: "ApplyCountImageModels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyCount",
                table: "ApplyCountImageModels");

            migrationBuilder.AddColumn<int>(
                name: "ApplyCount",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
