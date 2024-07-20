using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeMateriaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoNotaFiscal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdItemPedidoInterno",
                table: "ItemOrdemCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaFiscal",
                table: "Estoques",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdItemPedidoInterno",
                table: "ItemOrdemCompra");

            migrationBuilder.DropColumn(
                name: "NotaFiscal",
                table: "Estoques");
        }
    }
}
