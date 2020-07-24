using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class alteracao_ProdutosDb_primaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "codbar",
                table: "ProdutosDb",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosDb",
                table: "ProdutosDb",
                column: "codbar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosDb",
                table: "ProdutosDb");

            migrationBuilder.AlterColumn<string>(
                name: "codbar",
                table: "ProdutosDb",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30);
        }
    }
}
