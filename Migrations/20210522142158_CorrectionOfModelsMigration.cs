using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstWebApp.Migrations
{
    public partial class CorrectionOfModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Suppliers");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Tracks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Tracks",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Suppliers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
