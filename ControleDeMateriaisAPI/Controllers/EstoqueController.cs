using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeMateriaisAPI.Controllers
{
    [ApiController]

    [Route("api/estoque")]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueRepositorio _estoque;
        public EstoqueController(IEstoqueRepositorio estoque)
        {
            _estoque = estoque;
        }

        [HttpGet("/listaEstoque")]
        public async Task<ActionResult<IEnumerable<Estoque>>> ListaEstoque()
        {
            try
            {
                var listaEstoque = await _estoque.ListaEstoque();
                return listaEstoque.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("/cadastraEstoque")]
        public async Task<bool> AdicionarEstoque(Estoque estoque)
        {
            try
            {
                var adicionarEstoque = await _estoque.CadastrarEstoque(estoque);
                return adicionarEstoque;
            }
            catch
            {

                throw;
            }
        }

        [HttpGet("/buscaEstoque/{idEstoque}")]
        public async Task<ActionResult<Estoque>> ListaEstoque(int idEstoque)
        {
            try
            {
                var buscaEstoque = await _estoque.BuscaEstoquePorId(idEstoque);
                return buscaEstoque;
            }
            catch
            {
                throw;
            }
        }

   

        [HttpPut ("/atualizarEstoque")]
        public async Task<bool> AtualizarEstoque (Estoque estoque)
        {
            try
            {
                var atualizar = await _estoque.AtualizarEstoque(estoque);
                return atualizar;
            }
            catch 
            {

                throw;
            }
        }

        [HttpDelete ("/deletarEstoque")]
        public async Task<bool> DeletarEstoque (Estoque estoque)
        {
            try
            {
                var delete = await _estoque.DeletarEstoque(estoque);
                return delete;
            }
            catch
            {
                throw;
            }
        }

    }
}
