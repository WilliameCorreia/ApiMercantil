using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class Estabelecimento_ativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "estabelecimentos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "estabelecimentos");
        }
    }
}
