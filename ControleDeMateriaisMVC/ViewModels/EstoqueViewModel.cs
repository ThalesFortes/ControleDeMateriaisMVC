using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisMVC.ViewModels
{
    public class EstoqueViewModel
    {
        public int IdEstoque { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public int NotaFiscal { get; set; }
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
