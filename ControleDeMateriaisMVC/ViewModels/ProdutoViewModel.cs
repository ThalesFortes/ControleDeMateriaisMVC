using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisMVC.ViewModels
{
    public class ProdutoViewModel
    {
        public int IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoEAN { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int CotaMinimaEstoque { get; set; }
        public bool? Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public ICollection<Estoque> Estoques { get; set; }
        public ICollection<ItemPedidoInterno> ItemPedidoInternos { get; set; }
    }
}
