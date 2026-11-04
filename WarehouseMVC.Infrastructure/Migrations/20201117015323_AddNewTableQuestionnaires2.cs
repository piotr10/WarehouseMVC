using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class AddNewTableQuestionnaires2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Questionnaires",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfIssue",
                table: "Questionnaires",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdentityCardNumber",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuingAuthority",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Pesel",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBirth",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "DateOfIssue",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "IdentityCardNumber",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "IssuingAuthority",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "PlaceOfBirth",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Questionnaires");
        }
    }
}
