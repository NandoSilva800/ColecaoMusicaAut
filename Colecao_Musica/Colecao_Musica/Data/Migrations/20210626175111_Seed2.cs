using Microsoft.EntityFrameworkCore.Migrations;

namespace Colecao_Musica.Data.Migrations
{
    public partial class Seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artistas",
                columns: new[] { "Id", "Nacionalidade", "Nome", "Url", "UserNameId" },
                values: new object[,]
                {
                    { 2, "UK", "Queen", "https://queen.com/", null },
                    { 3, "UK", "Pink Floyd", "https://pinkfloyd.com/", null },
                    { 4, "UK", "Dire Straits", "https://direstraits.com/", null },
                    { 5, "UK", "Led Zeppelin", "https://ledzeppelin.com/", null },
                    { 6, "Australia", "AC/DC", "https://acdc.com/", null }
                });

            migrationBuilder.UpdateData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duracao",
                value: "4");

            migrationBuilder.InsertData(
                table: "Albuns",
                columns: new[] { "Id", "Ano", "ArtistasFK", "Cover", "Duracao", "Editora", "GenerosFK", "NrFaixas", "Titulo" },
                values: new object[,]
                {
                    { 2, "1996", 2, "anightoperaCover.png", "60", "Asylom Records", 1, "9", "A night at Opera" },
                    { 3, "1986", 3, "divisionbellCover.png", "80", "Asylom Records", 1, "9", "Division Bell" }
                });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Ano", "ArtistasFK", "Compositor", "Duracao", "Titulo" },
                values: new object[,]
                {
                    { 2, "1996", 2, null, "7", "Bhoeamian Rapsody" },
                    { 3, "1986", 3, null, "5", "Divisio Bell" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albuns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albuns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duracao",
                value: "6");
        }
    }
}
