using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class AddGroupMangerAndGroupLeaderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupLeaderId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GroupLeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLeaders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GroupLeaderId",
                table: "Images",
                column: "GroupLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_GroupLeaders_GroupLeaderId",
                table: "Images",
                column: "GroupLeaderId",
                principalTable: "GroupLeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_GroupLeaders_GroupLeaderId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "GroupLeaders");

            migrationBuilder.DropIndex(
                name: "IX_Images_GroupLeaderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GroupLeaderId",
                table: "Images");
        }
    }
}
