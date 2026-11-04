using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class AddCompanyToQuestionnaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_CompanyId",
                table: "Questionnaires",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Companies_CompanyId",
                table: "Questionnaires",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Companies_CompanyId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_CompanyId",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Questionnaires");
        }
    }
}
