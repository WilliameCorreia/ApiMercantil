using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class telefoneUnification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_telefones_estabelecimentos_EstabelecimentoId",
                table: "telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_telefones",
                table: "telefones");

            migrationBuilder.RenameTable(
                name: "telefones",
                newName: "Telefones");

            migrationBuilder.RenameIndex(
                name: "IX_telefones_EstabelecimentoId",
                table: "Telefones",
                newName: "IX_Telefones_EstabelecimentoId");

            migrationBuilder.AddColumn<string>(
                name: "Telefones",
                table: "estabelecimentos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_estabelecimentos_EstabelecimentoId",
                table: "Telefones",
                column: "EstabelecimentoId",
                principalTable: "estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_estabelecimentos_EstabelecimentoId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "Telefones",
                table: "estabelecimentos");

            migrationBuilder.RenameTable(
                name: "Telefones",
                newName: "telefones");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_EstabelecimentoId",
                table: "telefones",
                newName: "IX_telefones_EstabelecimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_telefones",
                table: "telefones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_telefones_estabelecimentos_EstabelecimentoId",
                table: "telefones",
                column: "EstabelecimentoId",
                principalTable: "estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
