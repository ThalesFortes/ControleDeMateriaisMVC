using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class PedidoInterno
    {
        [Key]
        public int IdPedidoInterno { get; set; } 
        public int IdUsuario { get; set; }
        public int IdServico { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Servico Servico { get; set; }
        public ICollection<ItemPedidoInterno> ItemPedidoInternos { get; set; }
    }
}
