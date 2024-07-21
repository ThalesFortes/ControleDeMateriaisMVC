using ControleDeMateriaisAPI.Models;

namespace ControleDeMateriaisAPI.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> ListaUsuario();
        Task<Usuario> BuscarUsuarioPorId(int idUsuario);
        Task<bool> CadastrarUsuario(Usuario usuario);
        Task<bool> AtualizarUsuario(Usuario usuario);
        Task<bool> DeletarUsuario(Usuario usuario);
    }
}
