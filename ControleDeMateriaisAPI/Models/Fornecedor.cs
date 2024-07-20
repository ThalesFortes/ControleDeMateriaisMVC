using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class Fornecedor
    {
        [Key]
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string Endereco { get; set; }
        public string EmailFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<OrdemCompra> OrdemCompras { get; set; }
    }
}
