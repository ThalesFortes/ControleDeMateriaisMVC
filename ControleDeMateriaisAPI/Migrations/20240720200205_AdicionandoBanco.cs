using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeMateriaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    IdFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.IdFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Usuarios_Departamentos_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemCompras",
                columns: table => new
                {
                    IdOrdemCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemCompras", x => x.IdOrdemCompra);
                    table.ForeignKey(
                        name: "FK_OrdemCompras_Fornecedores_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoEAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CotaMinimaEstoque = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrazoEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioMatricula = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servicos_Usuarios_UsuarioMatricula",
                        column: x => x.UsuarioMatricula,
                        principalTable: "Usuarios",
                        principalColumn: "Matricula");
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    IdEstoque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.IdEstoque);
                    table.ForeignKey(
                        name: "FK_Estoques_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosInternos",
                columns: table => new
                {
                    IdPedidoInterno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosInternos", x => x.IdPedidoInterno);
                    table.ForeignKey(
                        name: "FK_PedidosInternos_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosInternos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPedidoInterno",
                columns: table => new
                {
                    IdItemPedidoInterno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedidoInterno = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicoIdServico = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidoInterno", x => x.IdItemPedidoInterno);
                    table.ForeignKey(
                        name: "FK_ItemPedidoInterno_PedidosInternos_IdPedidoInterno",
                        column: x => x.IdPedidoInterno,
                        principalTable: "PedidosInternos",
                        principalColumn: "IdPedidoInterno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidoInterno_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidoInterno_Servicos_ServicoIdServico",
                        column: x => x.ServicoIdServico,
                        principalTable: "Servicos",
                        principalColumn: "IdServico");
                });

            migrationBuilder.CreateTable(
                name: "ItemOrdemCompra",
                columns: table => new
                {
                    IdItemOrdemCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdemCompra = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemPedidoInternoIdItemPedidoInterno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrdemCompra", x => x.IdItemOrdemCompra);
                    table.ForeignKey(
                        name: "FK_ItemOrdemCompra_ItemPedidoInterno_ItemPedidoInternoIdItemPedidoInterno",
                        column: x => x.ItemPedidoInternoIdItemPedidoInterno,
                        principalTable: "ItemPedidoInterno",
                        principalColumn: "IdItemPedidoInterno");
                    table.ForeignKey(
                        name: "FK_ItemOrdemCompra_OrdemCompras_IdOrdemCompra",
                        column: x => x.IdOrdemCompra,
                        principalTable: "OrdemCompras",
                        principalColumn: "IdOrdemCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_IdProduto",
                table: "Estoques",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrdemCompra_IdOrdemCompra",
                table: "ItemOrdemCompra",
                column: "IdOrdemCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrdemCompra_ItemPedidoInternoIdItemPedidoInterno",
                table: "ItemOrdemCompra",
                column: "ItemPedidoInternoIdItemPedidoInterno");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoInterno_IdPedidoInterno",
                table: "ItemPedidoInterno",
                column: "IdPedidoInterno");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoInterno_IdProduto",
                table: "ItemPedidoInterno",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoInterno_ServicoIdServico",
                table: "ItemPedidoInterno",
                column: "ServicoIdServico");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemCompras_IdFornecedor",
                table: "OrdemCompras",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosInternos_IdServico",
                table: "PedidosInternos",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosInternos_IdUsuario",
                table: "PedidosInternos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdFornecedor",
                table: "Produtos",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_UsuarioMatricula",
                table: "Servicos",
                column: "UsuarioMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdDepartamento",
                table: "Usuarios",
                column: "IdDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "ItemOrdemCompra");

            migrationBuilder.DropTable(
                name: "ItemPedidoInterno");

            migrationBuilder.DropTable(
                name: "OrdemCompras");

            migrationBuilder.DropTable(
                name: "PedidosInternos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
