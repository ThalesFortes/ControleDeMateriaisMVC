using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisMVC.Models
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
        public int IdOrdemCompra { get; set; }
    }
}
