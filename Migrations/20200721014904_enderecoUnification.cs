using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class enderecoUnification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_estabelecimentos_EstabelecimentoId",
                table: "enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos");

            migrationBuilder.RenameTable(
                name: "enderecos",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_enderecos_EstabelecimentoId",
                table: "Enderecos",
                newName: "IX_Enderecos_EstabelecimentoId");

            migrationBuilder.AddColumn<string>(
                name: "Enderecos",
                table: "estabelecimentos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_estabelecimentos_EstabelecimentoId",
                table: "Enderecos",
                column: "EstabelecimentoId",
                principalTable: "estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_estabelecimentos_EstabelecimentoId",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Enderecos",
                table: "estabelecimentos");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_EstabelecimentoId",
                table: "enderecos",
                newName: "IX_enderecos_EstabelecimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_estabelecimentos_EstabelecimentoId",
                table: "enderecos",
                column: "EstabelecimentoId",
                principalTable: "estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
