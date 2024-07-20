using ControleDeMateriaisAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ControleDeMateriaisAPI.Data
{
    public class ControleDeMateriaisContext : DbContext
    {
        public ControleDeMateriaisContext(DbContextOptions<ControleDeMateriaisContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<OrdemCompra> OrdemCompras { get; set; }
        public DbSet<PedidoInterno> PedidosInternos { get; set; }
        public DbSet<ItemOrdemCompra> ItemOrdemCompra { get; set; }
        public DbSet<ItemPedidoInterno> ItemPedidoInterno { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estoque> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                        .HasOne(c => c.Departamento)
                        .WithMany(p => p.Usuarios)
                        .HasForeignKey(io => io.IdDepartamento);

            modelBuilder.Entity<PedidoInterno>()
                        .HasOne(c => c.Servico)
                        .WithMany(oc => oc.PedidoInternos)
                        .HasForeignKey(io => io.IdServico);

            modelBuilder.Entity<PedidoInterno>()
                        .HasOne(c => c.Usuario)
                        .WithMany(oc => oc.PedidoInternos)
                        .HasForeignKey(io => io.IdUsuario);

            modelBuilder.Entity<ItemPedidoInterno>()
                        .HasOne(c => c.PedidoInterno)
                        .WithMany(oc => oc.ItemPedidoInternos)
                        .HasForeignKey(io => io.IdPedidoInterno);

            modelBuilder.Entity<ItemPedidoInterno>()
                        .HasOne(c => c.Produto)
                        .WithMany(oc => oc.ItemPedidoInternos)
                        .HasForeignKey(io => io.IdProduto);

            modelBuilder.Entity<OrdemCompra>()
                        .HasOne(c => c.Fornecedor)
                        .WithMany(oc => oc.OrdemCompras)
                        .HasForeignKey(io => io.IdFornecedor);

            modelBuilder.Entity<ItemOrdemCompra>()
                        .HasOne(c => c.OrdemCompra)
                        .WithMany(oc => oc.ItemOrdemCompras)
                        .HasForeignKey(io => io.IdOrdemCompra);

            modelBuilder.Entity<Produto>()
                        .HasOne(c => c.Fornecedor)
                        .WithMany(oc => oc.Produtos)
                        .HasForeignKey(io => io.IdFornecedor);

            modelBuilder.Entity<Estoque>()
                        .HasOne(c => c.Produto)
                        .WithMany(oc => oc.Estoques)
                        .HasForeignKey(io => io.IdProduto);
        }
    }
}
