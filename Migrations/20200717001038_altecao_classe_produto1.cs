using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class altecao_classe_produto1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoMedio",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoAcento",
                table: "produtos");

            migrationBuilder.AddColumn<bool>(
                name: "Oferta",
                table: "produtos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oferta",
                table: "produtos");

            migrationBuilder.AddColumn<string>(
                name: "PrecoMedio",
                table: "produtos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdutoAcento",
                table: "produtos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
