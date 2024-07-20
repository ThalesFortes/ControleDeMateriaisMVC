using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class Servico
    {
        [Key]
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public string DescricaoServico { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<PedidoInterno> PedidoInternos { get; set; }
        public ICollection<ItemPedidoInterno> ItemPedidoInternos { get; set; }
    }
}
