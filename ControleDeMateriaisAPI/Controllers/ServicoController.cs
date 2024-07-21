using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMateriaisAPI.Controllers
{
    [ApiController]
    [Route("api/servico")]

    public class ServicoController : Controller
    {
        private readonly IServicoRepositorio _servico;
        public ServicoController(IServicoRepositorio servico)
        {
            _servico = servico;
        }


        [HttpGet("/listaServico")]
        public async Task<ActionResult<IEnumerable<Servico>>> ListaServico()
        {
            try
            {
                var listaServico = await _servico.ListaServico();
                return listaServico.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("/cadastraServico")]
        public async Task<bool> AdicionarServico(Servico servico)
        {
            try
            {
                var adicionarServico = await _servico.CadastrarServico(servico);
                return adicionarServico;
            }
            catch
            {

                throw;
            }
        }

        [HttpPut("/atualizarServico")]
        public async Task<bool> AtualizarServico(Servico servico)
        {
            try
            {
                var atualizar = await _servico.AtualizarServico(servico);
                return atualizar;
            }
            catch
            {

                throw;
            }
        }

        [HttpDelete("/deletarServico")]
        public async Task<bool> DeletarServico(Servico servico)
        {
            try
            {
                var delete = await _servico.DeletarServico(servico);
                return delete;
            }
            catch
            {
                throw;
            }
        }

    }
}
