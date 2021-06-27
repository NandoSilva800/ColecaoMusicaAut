using Microsoft.EntityFrameworkCore.Migrations;

namespace Colecao_Musica.Data.Migrations
{
    public partial class register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Musicas",
                newName: "Título");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Albuns",
                newName: "Título");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Título",
                table: "Musicas",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Título",
                table: "Albuns",
                newName: "Titulo");
        }
    }
}
