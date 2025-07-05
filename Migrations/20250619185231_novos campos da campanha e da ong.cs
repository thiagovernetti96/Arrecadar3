using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arrecadar3.Migrations
{
    public partial class novoscamposdacampanhaedaong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto_Perfil_Url",
                table: "Ong");

            migrationBuilder.DropColumn(
                name: "Imagem_Url",
                table: "Campanha");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_Perfil",
                table: "Ong",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_Perfil",
                table: "Campanha",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampanhaId = table.Column<int>(type: "int", nullable: false),
                    Valor_Doado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Metodo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacao_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_CampanhaId",
                table: "Doacao",
                column: "CampanhaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropColumn(
                name: "Foto_Perfil",
                table: "Ong");

            migrationBuilder.DropColumn(
                name: "Foto_Perfil",
                table: "Campanha");

            migrationBuilder.AddColumn<string>(
                name: "Foto_Perfil_Url",
                table: "Ong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem_Url",
                table: "Campanha",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
