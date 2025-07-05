using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arrecadar3.Migrations
{
    public partial class AlteraçãonaCampanha2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor_Arrecadado",
                table: "Campanha",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor_Arrecadado",
                table: "Campanha");
        }
    }
}
