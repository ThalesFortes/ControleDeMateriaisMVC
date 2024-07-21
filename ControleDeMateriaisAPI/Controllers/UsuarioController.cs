using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMateriaisAPI.Controllers
{
    [ApiController]
    [Route("api/usuario")]

    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuario;
        public UsuarioController(IUsuarioRepositorio usuario)
        {
            _usuario = usuario;
        }


        [HttpGet("/listaUsuario")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListaUsuario()
        {
            try
            {
                var listaUsuario = await _usuario.ListaUsuario();
                return listaUsuario.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("/cadastraUsuario")]
        public async Task<bool> AdicionarUsuario(Usuario usuario)
        {
            try
            {
                var adicionarUsuario = await _usuario.CadastrarUsuario(usuario);
                return adicionarUsuario;
            }
            catch
            {

                throw;
            }
        }

        [HttpPut("/atualizarUsuario")]
        public async Task<bool> AtualizarUsuario(Usuario usuario)
        {
            try
            {
                var atualizar = await _usuario.AtualizarUsuario(usuario);
                return atualizar;
            }
            catch
            {

                throw;
            }
        }

        [HttpDelete("/deletarUsuario")]
        public async Task<bool> DeletarUsuario(Usuario usuario)
        {
            try
            {
                var delete = await _usuario.DeletarUsuario(usuario);
                return delete;
            }
            catch
            {
                throw;
            }
        }
    }
}
