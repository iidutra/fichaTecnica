using Microsoft.EntityFrameworkCore.Migrations;

namespace fichaTecnica.Migrations
{
    public partial class IniciandoModelagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FichaTecnicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoDaFichaTecnica = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    RendimentoDaPorcao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemInsumos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoItemInsumo = table.Column<string>(nullable: true),
                    CustoUnitario = table.Column<double>(nullable: false),
                    CustoTotal = table.Column<double>(nullable: false),
                    TipoDeUnidadeDeMedida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInsumos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FichaTecnicaInsumos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FichaTecnicaId = table.Column<int>(nullable: false),
                    ItemInsumoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnicaInsumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaTecnicaInsumos_FichaTecnicas_FichaTecnicaId",
                        column: x => x.FichaTecnicaId,
                        principalTable: "FichaTecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichaTecnicaInsumos_ItemInsumos_ItemInsumoId",
                        column: x => x.ItemInsumoId,
                        principalTable: "ItemInsumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnicaInsumos_FichaTecnicaId",
                table: "FichaTecnicaInsumos",
                column: "FichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnicaInsumos_ItemInsumoId",
                table: "FichaTecnicaInsumos",
                column: "ItemInsumoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichaTecnicaInsumos");

            migrationBuilder.DropTable(
                name: "FichaTecnicas");

            migrationBuilder.DropTable(
                name: "ItemInsumos");
        }
    }
}
