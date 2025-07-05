using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arrecadar3.Migrations
{
    public partial class ReformulaçãodoModelDoação : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metodo",
                table: "Doacao");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Doacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Metodo",
                table: "Doacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Doacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
