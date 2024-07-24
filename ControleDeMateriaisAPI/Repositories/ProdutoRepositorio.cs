using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeMateriaisAPI.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ControleDeMateriaisContext _context;

        public ProdutoRepositorio(ControleDeMateriaisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ListaProduto()
        {
            return await _context.Produtos.ToListAsync();
        }
        public async Task<Produto> BuscaProdutoPorId(int idProduto)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == idProduto);
            return produto;
        }
        public async Task<bool> CadastrarProduto(Produto produto)
        {
            try
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> AtualizarProduto(Produto produto)
        {
            try
            {
                var findProduto = await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == produto.IdProduto);
                if (findProduto == null)
                {
                    return false;
                }
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeletarProduto(Produto produto)
        {
            try
            {
                var deleteProduto = await _context.Produtos.FirstOrDefaultAsync(x => x.IdProduto == produto.IdProduto);
                if (deleteProduto == null)
                {
                    return false;
                }
                deleteProduto.Status = false;
                _context.Produtos.Update(deleteProduto);
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
