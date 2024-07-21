﻿// <auto-generated />
using System;
using ControleDeMateriaisAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeMateriaisAPI.Migrations
{
    [DbContext(typeof(ControleDeMateriaisContext))]
    [Migration("20240721184511_Atualizando status para bool na tabela produto")]
    partial class Atualizandostatusparaboolnatabelaproduto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdDepartamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Estoque", b =>
                {
                    b.Property<int>("IdEstoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstoque"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("NotaFiscal")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdEstoque");

                    b.HasIndex("IdProduto");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Fornecedor", b =>
                {
                    b.Property<int>("IdFornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFornecedor"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InscricaoMunicipal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdFornecedor");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.ItemOrdemCompra", b =>
                {
                    b.Property<int>("IdItemOrdemCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdItemOrdemCompra"));

                    b.Property<int>("IdItemPedidoInterno")
                        .HasColumnType("int");

                    b.Property<int>("IdOrdemCompra")
                        .HasColumnType("int");

                    b.Property<int?>("ItemPedidoInternoIdItemPedidoInterno")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdItemOrdemCompra");

                    b.HasIndex("IdOrdemCompra");

                    b.HasIndex("ItemPedidoInternoIdItemPedidoInterno");

                    b.ToTable("ItemOrdemCompra");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.ItemPedidoInterno", b =>
                {
                    b.Property<int>("IdItemPedidoInterno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdItemPedidoInterno"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPedidoInterno")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("ServicoIdServico")
                        .HasColumnType("int");

                    b.HasKey("IdItemPedidoInterno");

                    b.HasIndex("IdPedidoInterno");

                    b.HasIndex("IdProduto");

                    b.HasIndex("ServicoIdServico");

                    b.ToTable("ItemPedidoInterno");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.OrdemCompra", b =>
                {
                    b.Property<int>("IdOrdemCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrdemCompra"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdOrdemCompra");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("OrdemCompras");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.PedidoInterno", b =>
                {
                    b.Property<int>("IdPedidoInterno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedidoInterno"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdServico")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPedidoInterno");

                    b.HasIndex("IdServico");

                    b.HasIndex("IdUsuario");

                    b.ToTable("PedidosInternos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"));

                    b.Property<string>("CodigoEAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CotaMinimaEstoque")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("NomeProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Servico", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServico"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoServico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeServico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PrazoEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioMatricula")
                        .HasColumnType("int");

                    b.HasKey("IdServico");

                    b.HasIndex("UsuarioMatricula");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Matricula"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Matricula");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Estoque", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.Produto", "Produto")
                        .WithMany("Estoques")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.ItemOrdemCompra", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.OrdemCompra", "OrdemCompra")
                        .WithMany("ItemOrdemCompras")
                        .HasForeignKey("IdOrdemCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeMateriaisAPI.Models.ItemPedidoInterno", null)
                        .WithMany("ItemOrdemCompras")
                        .HasForeignKey("ItemPedidoInternoIdItemPedidoInterno");

                    b.Navigation("OrdemCompra");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.ItemPedidoInterno", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.PedidoInterno", "PedidoInterno")
                        .WithMany("ItemPedidoInternos")
                        .HasForeignKey("IdPedidoInterno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeMateriaisAPI.Models.Produto", "Produto")
                        .WithMany("ItemPedidoInternos")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeMateriaisAPI.Models.Servico", null)
                        .WithMany("ItemPedidoInternos")
                        .HasForeignKey("ServicoIdServico");

                    b.Navigation("PedidoInterno");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.OrdemCompra", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.Fornecedor", "Fornecedor")
                        .WithMany("OrdemCompras")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.PedidoInterno", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.Servico", "Servico")
                        .WithMany("PedidoInternos")
                        .HasForeignKey("IdServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeMateriaisAPI.Models.Usuario", "Usuario")
                        .WithMany("PedidoInternos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Produto", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Servico", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.Usuario", null)
                        .WithMany("Servicos")
                        .HasForeignKey("UsuarioMatricula");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Usuario", b =>
                {
                    b.HasOne("ControleDeMateriaisAPI.Models.Departamento", "Departamento")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Departamento", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Fornecedor", b =>
                {
                    b.Navigation("OrdemCompras");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.ItemPedidoInterno", b =>
                {
                    b.Navigation("ItemOrdemCompras");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.OrdemCompra", b =>
                {
                    b.Navigation("ItemOrdemCompras");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.PedidoInterno", b =>
                {
                    b.Navigation("ItemPedidoInternos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Produto", b =>
                {
                    b.Navigation("Estoques");

                    b.Navigation("ItemPedidoInternos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Servico", b =>
                {
                    b.Navigation("ItemPedidoInternos");

                    b.Navigation("PedidoInternos");
                });

            modelBuilder.Entity("ControleDeMateriaisAPI.Models.Usuario", b =>
                {
                    b.Navigation("PedidoInternos");

                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
