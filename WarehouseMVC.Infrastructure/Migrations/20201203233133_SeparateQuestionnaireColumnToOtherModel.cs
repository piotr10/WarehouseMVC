using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class SeparateQuestionnaireColumnToOtherModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTag");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageModelRef",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_CompanyId",
                table: "Questionnaires",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_ImageModelRef",
                table: "Questionnaires",
                column: "ImageModelRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CompanyId",
                table: "Images",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Images_ImageModelRef",
                table: "Questionnaires",
                column: "ImageModelRef",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Companies_CompanyId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Companies_CompanyId",
                table: "Questionnaires");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Images_ImageModelRef",
                table: "Questionnaires");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_CompanyId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_ImageModelRef",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Images_CompanyId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "ImageModelRef",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTag",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTag", x => new { x.ItemId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ItemTag_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_TagId",
                table: "ItemTag",
                column: "TagId");
        }
    }
}
