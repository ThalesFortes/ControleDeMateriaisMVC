using System.ComponentModel.DataAnnotations;

namespace ControleDeMateriaisAPI.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }
        public string NomeDepartamento { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
