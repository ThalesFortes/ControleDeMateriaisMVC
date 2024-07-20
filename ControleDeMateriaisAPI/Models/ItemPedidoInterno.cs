using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class ItemPedidoInterno
    {
        [Key]
        public int IdItemPedidoInterno { get; set; }
        public int IdPedidoInterno { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual PedidoInterno PedidoInterno { get; set; }
        public virtual Produto Produto { get; set; }
        public ICollection<ItemOrdemCompra> ItemOrdemCompras { get; set; }

    }
}
