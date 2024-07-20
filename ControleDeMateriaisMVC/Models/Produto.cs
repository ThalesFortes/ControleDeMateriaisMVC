using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeMateriaisMVC.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("IdProduto")]
        [Display(Name = "Código")]
        [Key]
        public int IdProduto { get; set; }

        [Column("NomeProduto")]
        [Display(Name = "Nome Produto")]

        public string? NomeProduto { get; set; }

        [Column("CodigoEAN")]
        [Display(Name = "CodigoEAN")]
        public string? CodigoEAN { get; set; }

        [Column("PrecoUnitario")]
        [Display(Name = "PrecoUnitario")]
        public decimal PrecoUnitario { get; set; }

        [Column("CotaMinimaEstoque")]
        [Display(Name = "CotaMinimaEstoque")]
        public int CotaMinimaEstoque { get; set; }

        [Column("IdFornecedor")]
        [Display(Name = "CodigoFornecedor")]
        public int? IdFornecedor { get; set; } // Fornecedor principal (opcional)

        [Column("Status")]
        [Display(Name = "Status")]
        public string? Status { get; set; } // Ativo, Inativo

       
    }

    

    

}
