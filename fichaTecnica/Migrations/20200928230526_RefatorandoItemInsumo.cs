using Microsoft.EntityFrameworkCore.Migrations;

namespace fichaTecnica.Migrations
{
    public partial class RefatorandoItemInsumo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItemInsumos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItemInsumos");
        }
    }
}
