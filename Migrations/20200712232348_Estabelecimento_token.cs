using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class Estabelecimento_token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "estabelecimentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "estabelecimentos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "estabelecimentos");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "estabelecimentos");
        }
    }
}
