using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeMateriaisAPI.Repositories
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly ControleDeMateriaisContext _context;

        public EstoqueRepositorio(ControleDeMateriaisContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Estoque>> ListaEstoque()
        {
            return await _context.Estoques.ToListAsync();
        }
        public async Task<Estoque> BuscaEstoquePorId(int idEstoque)
        {
            var estoque = await _context.Estoques.FirstOrDefaultAsync(x => x.IdEstoque == idEstoque);
            return estoque;
        }
        public async Task<bool> AdicionarEstoque(Estoque estoque)
        {
            try
            {
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> AtualizarEstoque(Estoque estoque)
        {
            try
            {
                var findEstoque = await _context.Estoques.FirstOrDefaultAsync(x => x.IdEstoque == estoque.IdEstoque);
                if (findEstoque == null)
                {
                    return false;
                }
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletarEstoque(Estoque estoque)
        {
            try
            {
                var deleteEstoque = await _context.Estoques.FirstOrDefaultAsync(x => x.IdEstoque == estoque.IdEstoque);
                if (deleteEstoque == null)
                {
                    return false;
                }
                _context.Estoques.Remove(deleteEstoque);
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
