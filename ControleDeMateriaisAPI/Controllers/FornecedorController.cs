using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMateriaisAPI.Controllers
{
    [ApiController]
    [Route("api/fornecedor")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedor;
        public FornecedorController(IFornecedorRepositorio fornecedor)
        {
            _fornecedor = fornecedor;
        }


        [HttpGet("/listaFornecedor")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> ListaFornecedor()
        {
            try
            {
                var listaFornecedor = await _fornecedor.ListaFornecedor();
                return listaFornecedor.ToList();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("/cadastraFornecedor")]
        public async Task<bool> AdicionarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var adicionarFornecedor = await _fornecedor.CadastrarFornecedor(fornecedor);
                return adicionarFornecedor;
            }
            catch
            {

                throw;
            }
        }

        [HttpPut("/atualizarFornecedor")]
        public async Task<bool> AtualizarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var atualizar = await _fornecedor.AtualizarFornecedor(fornecedor);
                return atualizar;
            }
            catch
            {

                throw;
            }
        }

        [HttpDelete("/deletarFornecedor")]
        public async Task<bool> DeletarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var delete = await _fornecedor.DeletarFornecedor(fornecedor);
                return delete;
            }
            catch
            {
                throw;
            }
        }


    }
}
