using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class AddNewColumnInQuestionairesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountNumber",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commune",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Companies",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DegreeOfDisability",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlatNumber",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NationalHealthFund",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonAddress",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PersonPhone",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PersonSurname",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Postcode",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Retirement",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOffice",
                table: "Questionnaires",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Questionnaires",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Commune",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Companies",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "DegreeOfDisability",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "FlatNumber",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "NationalHealthFund",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "PersonAddress",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "PersonPhone",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "PersonSurname",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Retirement",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "TaxOffice",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Questionnaires");
        }
    }
}
