using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMateriaisAPI.Controllers
{
    [ApiController]
    [Route("api/produto")]

    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produto;
        public ProdutoController(IProdutoRepositorio produto)
        {
            _produto = produto;
        }


        [HttpGet("/listaProduto")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListaProduto()
        {
            try
            {
                var listaProduto = await _produto.ListaProduto();
                return listaProduto.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("/cadastraProduto")]
        public async Task<bool> AdicionarProduto(Produto produto)
        {
            try
            {
                var adicionarEstoque = await _produto.CadastrarProduto(produto);
                return adicionarEstoque;
            }
            catch
            {

                throw;
            }
        }

        [HttpPut("/atualizarProduto")]
        public async Task<bool> AtualizarProduto(Produto produto)
        {
            try
            {
                var atualizar = await _produto.AtualizarProduto(produto);
                return atualizar;
            }
            catch
            {

                throw;
            }
        }

        [HttpDelete("/deletarProduto")]
        public async Task<bool> DeletarProduto(Produto produto)
        {
            try
            {
                var delete = await _produto.DeletarProduto(produto);
                return delete;
            }
            catch
            {
                throw;
            }
        }


    }
}
