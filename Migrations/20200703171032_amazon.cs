using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMercantil.Migrations
{
    public partial class amazon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutosDb",
                columns: table => new
                {
                    codbar = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    produto = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    produto_upper = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    produto_acento = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    peso = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ncm = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    cest_codigo = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    embalagem = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    quantidade_embalagem = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    foto_png = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    foto_gif = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    marca = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    preco_medio = table.Column<float>(nullable: true),
                    img_gtin = table.Column<string>(maxLength: 255, nullable: true),
                    categoria = table.Column<string>(maxLength: 100, nullable: true),
                    foto_tabloide_png = table.Column<string>(maxLength: 255, nullable: true),
                    foto_tabloide_gif = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosDb");
        }
    }
}
