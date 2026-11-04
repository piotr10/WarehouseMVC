using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class DeleteRealtionOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Images_ImageModelRef",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_ImageModelRef",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "ImageModelRef",
                table: "Questionnaires");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageModelRef",
                table: "Questionnaires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_ImageModelRef",
                table: "Questionnaires",
                column: "ImageModelRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Images_ImageModelRef",
                table: "Questionnaires",
                column: "ImageModelRef",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
