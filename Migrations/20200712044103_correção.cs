using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class correção : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "produtos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_produtos_EstabelecimentoId",
                table: "produtos",
                column: "EstabelecimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_estabelecimentos_EstabelecimentoId",
                table: "produtos",
                column: "EstabelecimentoId",
                principalTable: "estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produtos_estabelecimentos_EstabelecimentoId",
                table: "produtos");

            migrationBuilder.DropIndex(
                name: "IX_produtos_EstabelecimentoId",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "produtos");
        }
    }
}
