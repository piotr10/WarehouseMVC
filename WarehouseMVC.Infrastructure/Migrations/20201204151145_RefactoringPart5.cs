using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class RefactoringPart5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Companies_CompanyId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_CompanyId",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Questionnaires");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Questionnaires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_CompanyId",
                table: "Questionnaires",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Companies_CompanyId",
                table: "Questionnaires",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
