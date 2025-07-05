using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arrecadar3.Migrations
{
    public partial class AlteracaoAtualizaçãodecampanhas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem_Url",
                table: "Atualizacao_Campanha");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_Perfil",
                table: "Atualizacao_Campanha",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto_Perfil",
                table: "Atualizacao_Campanha");

            migrationBuilder.AddColumn<string>(
                name: "Imagem_Url",
                table: "Atualizacao_Campanha",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
