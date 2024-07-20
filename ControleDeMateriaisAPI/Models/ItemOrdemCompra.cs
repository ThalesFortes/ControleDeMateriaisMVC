using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class ItemOrdemCompra
    {
        [Key]
        public int IdItemOrdemCompra { get; set; }
        public int IdOrdemCompra { get; set; }
        public int IdItemPedidoInterno { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public virtual OrdemCompra OrdemCompra { get; set; }
    }
}
