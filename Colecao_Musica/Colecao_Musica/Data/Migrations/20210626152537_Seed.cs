using Microsoft.EntityFrameworkCore.Migrations;

namespace Colecao_Musica.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artistas",
                columns: new[] { "Id", "Nacionalidade", "Nome", "Url", "UserNameId" },
                values: new object[] { 1, "USA", "Eagles", "https://eagles.com/", null });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Designacao" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Dance" },
                    { 4, "Classica" },
                    { 5, "Fado" },
                    { 6, "Ópera" },
                    { 7, "Heavy Metal" },
                    { 8, "Jazz" }
                });

            migrationBuilder.InsertData(
                table: "Albuns",
                columns: new[] { "Id", "Ano", "ArtistasFK", "Cover", "Duracao", "Editora", "GenerosFK", "NrFaixas", "Titulo" },
                values: new object[] { 1, "1976", 1, "HotelCaliforniaAlbumCover.png", "43", "Asylom Records", 1, "9", "Hotel Califórnia" });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Ano", "ArtistasFK", "Compositor", "Duracao", "Titulo" },
                values: new object[] { 1, "1976", 1, null, "6", "Hotel Califórnia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albuns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artistas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
