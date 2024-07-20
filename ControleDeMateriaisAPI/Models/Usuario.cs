using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Matricula { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }
        public int IdDepartamento { get; set; }
        public virtual Departamento Departamento { get; set; }
        public ICollection<Servico> Servicos { get; set; }
        public ICollection<PedidoInterno> PedidoInternos { get; set; }
    }
}
