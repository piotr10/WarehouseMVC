using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class AddDateTimeAcceptAndDenied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptDateTime",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeniedDateTime",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptDateTime",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeniedDateTime",
                table: "Images");
        }
    }
}
