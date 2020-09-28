using Microsoft.EntityFrameworkCore.Migrations;

namespace fichaTecnica.Migrations
{
    public partial class InserindoModelBuilders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaTecnicaInsumos_FichaTecnicas_FichaTecnicaId",
                table: "FichaTecnicaInsumos");

            migrationBuilder.DropForeignKey(
                name: "FK_FichaTecnicaInsumos_ItemInsumos_ItemInsumoId",
                table: "FichaTecnicaInsumos");

            migrationBuilder.AlterColumn<string>(
                name: "TipoDeUnidadeDeMedida",
                table: "ItemInsumos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoItemInsumo",
                table: "ItemInsumos",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoDaFichaTecnica",
                table: "FichaTecnicas",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "FichaTecnicas",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FichaTecnicaInsumos_FichaTecnicas_FichaTecnicaId",
                table: "FichaTecnicaInsumos",
                column: "FichaTecnicaId",
                principalTable: "FichaTecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FichaTecnicaInsumos_ItemInsumos_ItemInsumoId",
                table: "FichaTecnicaInsumos",
                column: "ItemInsumoId",
                principalTable: "ItemInsumos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaTecnicaInsumos_FichaTecnicas_FichaTecnicaId",
                table: "FichaTecnicaInsumos");

            migrationBuilder.DropForeignKey(
                name: "FK_FichaTecnicaInsumos_ItemInsumos_ItemInsumoId",
                table: "FichaTecnicaInsumos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeUnidadeDeMedida",
                table: "ItemInsumos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoItemInsumo",
                table: "ItemInsumos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoDaFichaTecnica",
                table: "FichaTecnicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "FichaTecnicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaTecnicaInsumos_FichaTecnicas_FichaTecnicaId",
                table: "FichaTecnicaInsumos",
                column: "FichaTecnicaId",
                principalTable: "FichaTecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichaTecnicaInsumos_ItemInsumos_ItemInsumoId",
                table: "FichaTecnicaInsumos",
                column: "ItemInsumoId",
                principalTable: "ItemInsumos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
