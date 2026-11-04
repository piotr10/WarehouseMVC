using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class AddNewAcceptDataToImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptDateTime",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeniedDateTime",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "AcceptDateTimeCfo",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcceptDateTimeControlling",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcceptDateTimeRecruitment",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptDateTimeCfo",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AcceptDateTimeControlling",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AcceptDateTimeRecruitment",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "AcceptDateTime",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeniedDateTime",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
