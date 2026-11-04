using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class AddGroupMangerTablePart6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupManagerId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GroupManagers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupManagers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GroupManagerId",
                table: "Images",
                column: "GroupManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_GroupManagers_GroupManagerId",
                table: "Images",
                column: "GroupManagerId",
                principalTable: "GroupManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_GroupManagers_GroupManagerId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "GroupManagers");

            migrationBuilder.DropIndex(
                name: "IX_Images_GroupManagerId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GroupManagerId",
                table: "Images");
        }
    }
}
