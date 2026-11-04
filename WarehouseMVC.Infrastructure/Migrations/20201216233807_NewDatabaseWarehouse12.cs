using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMVC.Infrastructure.Migrations
{
    public partial class NewDatabaseWarehouse12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Questionnaires",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "Questionnaires",
                maxLength: 26,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Pesel",
                table: "Questionnaires",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountNumber",
                table: "Questionnaires",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 26,
                oldNullable: true);
        }
    }
}
