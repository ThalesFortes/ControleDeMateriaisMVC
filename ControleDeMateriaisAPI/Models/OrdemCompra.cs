using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class OrdemCompra
    {
        [Key]
        public int IdOrdemCompra { get; set; }
        public int IdFornecedor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public ICollection<ItemOrdemCompra>  ItemOrdemCompras { get; set; }
    }
}
