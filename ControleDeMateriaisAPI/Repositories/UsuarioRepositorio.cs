using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeMateriaisAPI.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio

    {
        private readonly ControleDeMateriaisContext _context;
        public UsuarioRepositorio(ControleDeMateriaisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ListaUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Matricula == idUsuario);
            return usuario;
        }

        public async Task<bool> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> AtualizarUsuario(Usuario usuario)
        {
            try
            {
                var findUsuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Matricula == usuario.Matricula);
                if (findUsuario == null)
                {
                    return false;
                }
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletarUsuario(Usuario usuario)
        {
            try
            {
                var deleteUsuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Matricula == usuario.Matricula);
                if (deleteUsuario == null)
                {
                    return false;
                }
                deleteUsuario.Status = false;
                _context.Usuarios.Update(deleteUsuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}

