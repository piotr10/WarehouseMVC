using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class UpdateQuestionnaire3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Questionnaires");

            migrationBuilder.AddColumn<string>(
                name: "ImageNameQuestionnaire",
                table: "Questionnaires",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageNameQuestionnaire",
                table: "Questionnaires");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Questionnaires",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
